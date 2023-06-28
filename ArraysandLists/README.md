

## Arrays

we can use arrays to store many variables of the same type such as int,string

number of elements in an array cannot be changed after initialization

## Single Dimensional Arrays

A single dimension arrays stores a collection of items of the same type , which are
accessible by an index


## MultiDimension Arrays
The arrays in the C# language do not need to have only one dimension. It is also possible to create two-dimensional or even three-dimensional arrays

## extension methods

They are methods that are added to a particular existing type (both built in and user defined )
and can be called in the same way if they are defined as instance methods.
The declaration of an extension method requires you to specify it within a static class
as a static method with the first parameter indicating the type, to which you want to "add"
this method, with the this keyword


## Jagged Arrays

arrays of arrays
Single dimensional array where each element is an array, such inner arrays can have different
lengths and cannot even be initialized


A jagged array and a multidimensional array are both types of arrays in programming languages like C#. However, they differ in their structure and usage. Here are the key differences between jagged arrays and multidimensional arrays:

Jagged Array:

Structure: A jagged array is an array of arrays. It is essentially an array of one-dimensional arrays, where each inner array can have a different length. It is also known as an array of arrays or a ragged array.
Memory Allocation: The memory for a jagged array is allocated in a non-contiguous manner, as each inner array can have a different length and is allocated separately.
Declaration: In C#, a jagged array is declared using multiple square brackets [][]. For example: int[][] jaggedArray;
Accessing Elements: Elements in a jagged array are accessed using multiple indices. For example: jaggedArray[rowIndex][columnIndex].
Flexibility: Jagged arrays offer flexibility in terms of varying lengths for different rows, making them suitable for representing irregular or non-rectangular data structures.
Multidimensional Array:

Structure: A multidimensional array is a rectangular array with multiple dimensions. It can have two or more dimensions, where each dimension represents a specific axis or dimension of the array.
Memory Allocation: The memory for a multidimensional array is allocated in a contiguous block, as the entire array is treated as a single entity.
Declaration: In C#, a multidimensional array is declared using a single set of square brackets with the number of dimensions specified. For example: int[,] multiDimArray; (for a two-dimensional array) or int[,,] multiDimArray; (for a three-dimensional array).
Accessing Elements: Elements in a multidimensional array are accessed using a single set of square brackets with comma-separated indices. For example: multiDimArray[rowIndex, columnIndex].
Regular Structure: Multidimensional arrays have a regular structure with fixed dimensions, making them suitable for representing tabular or grid-like data structures.
In summary, jagged arrays are arrays of arrays with varying lengths for each inner array, while multidimensional arrays are rectangular arrays with fixed dimensions. The choice between jagged arrays and multidimensional arrays depends on the specific requirements and structure of the data you want to represent.




