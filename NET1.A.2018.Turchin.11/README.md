# NET1.A.2018.Turchin.11

1. <b>Add</b> an overloaded version that accepts a delegate to the class with the [real number array transformer method][transformer].  
2. Refactoring of the class (with the goal of reducing repeated code) in the [algorithms of Euclid][Euclid]. <b>The class interface should not change</b>.  
3. In a class with a [non-rectangular matrix sorting algorithm][matrix] that takes an interface as a comparator, <b>add</b> an overloaded method that takes a comparator delegate as a parameter that encapsulates the matrix string comparison logic.  
The class is implemented in two ways (two separate classes), "closing" in the first embodiment, the implementation of the sorting method with a delegate to a method with an interface (the method performs work with the parameter-interface, the method with the delegate calls it), in the second – Vice versa (the method performs work with the parameter-delegate, the method with the interface calls it).

[transformer]: https://github.com/TurchinAlexander/DotNetCourseTraining/blob/master/NET1.A.2018.Turchin.04/Algoritm/Calculate.cs
[Euclid]: https://github.com/TurchinAlexander/DotNetCourseTraining/blob/master/NET1.A.2018.Turchin.04/Algoritm/GCD.cs
[matrix]: https://github.com/TurchinAlexander/DotNetCourseTraining/blob/master/NET1.A.2018.Turchin.07/JaggedArray/JaggedSort.cs
