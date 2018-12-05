# NET1.A.2018.Turchin.19

The text file stores information about URLs in a line-by-line form

  ![Scheme](https://github.com/TurchinAlexander/DotNetCourseTraining/blob/master/NET1.A.2018.Turchin.19/Scheme.png)

where the parameters segment is a set of key=value pairs, and the URL‐path and parameters segments or the parameters segment may be missing.
Develop a type system (guided by SOLID principles) to export the data obtained from parsing the text file information to an XML document according to the following rule, for example, for a text file with URLS
  - https://github.com/AnzhelikaKravchuk?tab=repositories
  - https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU
  - https://habrahabr.ru/company/it-grad/blog/341486/      

the result is an XML document of the form (you can use any XML technology without restrictions).
![XML-resultat](https://github.com/TurchinAlexander/DotNetCourseTraining/blob/master/NET1.A.2018.Turchin.19/XML.Task.png)

  For those URLS that do not match this pattern, “pledge” the information by marking the specified strings as unprocessed.

  Demonstrate the work on the example of a [console application][Console].  

[Console]: https://github.com/TurchinAlexander/DotNetCourseTraining/tree/master/NET1.A.2018.Turchin.19/Console
