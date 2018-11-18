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
		private static Encoding encoding = Encoding.GetEncoding("iso-8859-1");

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

			StreamReader streamReader = new StreamReader(sourcePath);
			StreamWriter streamWriter = new StreamWriter(destinationPath);

			string fileText = streamReader.ReadToEnd();
			byte[] writeByteArray = new byte[1];
			int totalBytes = 0;
			
			MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(fileText));

			while(memoryStream.Read(writeByteArray, 0, 1) > 0)
			{
				streamWriter.Write(encoding.GetChars(writeByteArray));
				totalBytes++;
			}

			streamReader.Close();
			streamWriter.Close();
			memoryStream.Close();

			return totalBytes;
        }

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			const int bufferSize = 0x1000;

			FileStream fileRead = new FileStream(sourcePath, FileMode.Open);
			FileStream fileWrite = new FileStream(destinationPath, FileMode.Create);

			byte[] buffer = new byte[bufferSize];
			int totalBytes = 0;
			int bytesRead = 0;
			int offset = 0;

			while((bytesRead = fileRead.Read(buffer, offset, bufferSize)) > 0)
			{
				fileWrite.Write(buffer, offset, bytesRead);
				offset += bytesRead;
				totalBytes += bytesRead;
			}

			fileRead.Close();
			fileWrite.Close();

			return totalBytes;
		}

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			const int bufferSize = 0x1000;

			StreamReader streamReader = new StreamReader(sourcePath);
			StreamWriter streamWriter = new StreamWriter(destinationPath);
			string fileText = streamReader.ReadToEnd();

			byte[] writeByteArray = new byte[bufferSize];
			int bytesRead = 0;
			int offset = 0;
			int totalBytes = 0;

			MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(fileText));

			while ((bytesRead = memoryStream.Read(writeByteArray, offset, bufferSize)) > 0)
			{
				streamWriter.Write(encoding.GetChars(writeByteArray));
				offset += bytesRead;
				totalBytes += bytesRead;
			}

			streamReader.Close();
			streamWriter.Close();
			memoryStream.Close();

			return totalBytes;
		}

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			const int bufferSize = 0x1000;

			FileStream fileRead = new FileStream(sourcePath, FileMode.Open);
			FileStream fileWrite = new FileStream(destinationPath, FileMode.Create);
			BufferedStream bufferedStream = new BufferedStream(fileRead, bufferSize);

			byte[] buffer = new byte[bufferSize];
			int offset = 0;
			int totalBytes = 0;
			int bytesRead = 0;
			
			while ((bytesRead = bufferedStream.Read(buffer, offset, bufferSize)) > 0)
			{
				fileWrite.Write(buffer, offset, bytesRead);
				offset += bytesRead;
				totalBytes += bytesRead;
			}

			fileRead.Close();
			fileWrite.Close();

			return totalBytes;
		}

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			StreamReader streamReader = new StreamReader(sourcePath);
			StreamWriter streamWriter = new StreamWriter(destinationPath);
			int totalStrings = 0;
			string buffer;

			while(!streamReader.EndOfStream)
			{
				buffer = streamReader.ReadLine();
				streamWriter.WriteLine(buffer);
				totalStrings++;
			}

			streamReader.Close();
			streamWriter.Close();

			return totalStrings;
        }

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
			InputValidation(sourcePath, destinationPath);

			StreamReader sourceReader = new StreamReader(sourcePath);
			StreamReader destinationReader = new StreamReader(destinationPath);
			string firstString;
			string secondString;
			bool isEqual = true;

			while (!sourceReader.EndOfStream && !destinationReader.EndOfStream && isEqual)
			{
				firstString = sourceReader.ReadLine();
				secondString = destinationReader.ReadLine();
				isEqual = firstString.Equals(secondString);
			}

			if (!sourceReader.EndOfStream || !destinationReader.EndOfStream)
			{
				isEqual = false;
			}

			sourceReader.Close();
			destinationReader.Close();

			return isEqual;
		}

		private static void InputValidation(string sourcePath, string destinationPath)
		{
			if (sourcePath == null)
				throw new ArgumentNullException(nameof(sourcePath));

			if (destinationPath == null)
				throw new ArgumentNullException(nameof(destinationPath));

			/*if (!Directory.Exists(Path.GetDirectoryName(sourcePath)))
				throw new ArgumentException($"There is no such directory {Path.GetDirectoryName(sourcePath)}");*/

			if (!File.Exists(sourcePath))
				throw new ArgumentException($"There is no such file with that name {Path.GetFileName(sourcePath)}");

			/*if (!Directory.Exists(Path.GetDirectoryName(destinationPath)))
				throw new ArgumentException($"There is no such directory {Path.GetDirectoryName(sourcePath)}");*/
		}
    }
}
