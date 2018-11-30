using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			FileStream fileRead = new FileStream(sourcePath, FileMode.Open);
			FileStream fileWrite = new FileStream(destinationPath, FileMode.Create);

			int totalBytes = 0;
			int readByte = 0;

			while((readByte = fileRead.ReadByte()) != -1)
			{
				fileWrite.WriteByte((byte)readByte);
				totalBytes++;
			}

			fileRead.Close();
			fileWrite.Close();

			return totalBytes;
        }

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

            bool isBOM = CheckBOM(sourcePath);
            Encoding encoding = new UTF8Encoding(isBOM);

			string fileText;

            int bufferSize = 1;
            byte[] writeByteArray = new byte[bufferSize];
			int totalBytes = 0;

            using (StreamReader streamReader = new StreamReader(sourcePath, encoding))
            {
                fileText = streamReader.ReadToEnd();
            }

            using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(fileText)))
            using (FileStream fileStream = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                if (isBOM)
                {
                    fileStream.Write(encoding.GetPreamble(), 0, 3);
                    totalBytes += 3;
                }

                while (memoryStream.Read(writeByteArray, 0, bufferSize) > 0)
                {
                    fileStream.Write(writeByteArray, 0, bufferSize);
                    totalBytes++;
                }
            }

			return totalBytes;
        }

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

            const int bufferSize = 0x1000;
			byte[] buffer = new byte[bufferSize];
			int totalBytes = 0;
			int bytesRead;

            using (FileStream fileRead = new FileStream(sourcePath, FileMode.Open))
            using (FileStream fileWrite = new FileStream(destinationPath, FileMode.Create))
            {
                while ((bytesRead = fileRead.Read(buffer, 0, bufferSize)) > 0)
                {
                    fileWrite.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }
            }

			return totalBytes;
		}

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			const int bufferSize = 0x1000;
            string fileText;
			byte[] writeByteArray = new byte[bufferSize];
			int bytesRead = 0;
			int totalBytes = 0;
            bool isBOM = CheckBOM(sourcePath);

            Encoding encoding = new UTF8Encoding(isBOM);
            using (StreamReader streamReader = new StreamReader(sourcePath))
            {
                fileText = streamReader.ReadToEnd();
            }

            using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(fileText)))
            using (FileStream fileStream = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                if (isBOM)
                {
                    fileStream.Write(encoding.GetPreamble(), 0, 3);
                    totalBytes += 3;
                }

                while ((bytesRead = memoryStream.Read(writeByteArray, 0, bufferSize)) > 0)
                {
                    fileStream.Write(writeByteArray, 0, bufferSize);
                    totalBytes += bytesRead;
                }
            }

			return totalBytes;
		}

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			const int bufferSize = 0x1000;

			byte[] buffer = new byte[bufferSize];
            int totalBytes = 0;
			int bytesRead = 0;

            using (BufferedStream bufferedStream = new BufferedStream(
                new FileStream(sourcePath, FileMode.Open),
                bufferSize))
            using (FileStream fileWrite = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                while ((bytesRead = bufferedStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    fileWrite.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }
            }

			return totalBytes;
		}

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			
			int totalStrings = 0;
			string buffer;

            using (StreamReader streamReader = new StreamReader(sourcePath))
            using (StreamWriter streamWriter = new StreamWriter(destinationPath))
            {
                while (!streamReader.EndOfStream)
                {
                    buffer = streamReader.ReadLine();
                    streamWriter.WriteLine(buffer);
                    totalStrings++;
                }
            }

			return totalStrings;
        }

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            string firstString;
            string secondString;
            bool isEqual = true;

            FileStream sourceFile = new FileStream(sourcePath, FileMode.Open);
            FileStream destinationFile = new FileStream(destinationPath, FileMode.Open);

            if (sourceFile.Length != destinationFile.Length)
            {
                return false;
            }

            using (StreamReader sourceReader = new StreamReader(sourceFile))
            using (StreamReader destinationReader = new StreamReader(destinationFile))
            {
                while (!sourceReader.EndOfStream && !destinationReader.EndOfStream && isEqual)
                {
                    firstString = sourceReader.ReadLine();
                    secondString = destinationReader.ReadLine();
                    isEqual = firstString.Equals(secondString);
                }

                if (!sourceReader.EndOfStream || !destinationReader.EndOfStream)
                {
                    return false;
                }
            }

            return true;
		}

		private static void InputValidation(string sourcePath, string destinationPath)
		{
			if (sourcePath == null)
				throw new ArgumentNullException(nameof(sourcePath));

			if (destinationPath == null)
				throw new ArgumentNullException(nameof(destinationPath));

			if (!File.Exists(sourcePath))
				throw new ArgumentException($"There is no such file with that name {Path.GetFileName(sourcePath)}");
		}

        private static bool CheckBOM(string fileName)
        {
            byte[] bomArray = { 0xEF, 0xBB, 0xBF };
            bool hasBOM = true;

            using(FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] bits = new byte[bomArray.Length];
                fs.Read(bits, 0, bits.Length);

                int i = 0;
                while(i < bomArray.Length && hasBOM)
                {
                    hasBOM = (bomArray[i] == bits[i]);
                    i++;
                }
            }

            return hasBOM;
        }
    }
}
