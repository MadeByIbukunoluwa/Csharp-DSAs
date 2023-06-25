

## notes on the basic data types in C Sharp



Data types - values types and reference types 
—a variable of a value type directly contains data, while a variable of a reference type just stores a reference to data, as shown as follows:

Take care when updating an object that has a reference type because that. Change could also relict in objects referencing that same type 

Structs 

As for storing integer values, you can use one of the following types: Byte (the byte keyword), SByte (sbyte), Int16 (short), UInt16 (ushort), Int32 (int), UInt32 (uint), Int64 (long), and UInt64 (ulong). They differ by the number of bytes for storing values and therefore by the range of available values.

In the case of floating-point values, you can use two types, namely Single (float) and Double (double). The first uses 32 bits, while the second uses 64 bits. Thus, their precision differs significantly.

Enumerations Apart from structs, the value types contain enumerations. Each has a set of named constants to specify the available set of values.

The second main group of types is named reference types. Just as a quick reminder, a variable of a reference type does not directly contain data, because it just stores a reference to data. In this group, you can find three built-in types, namely string,


strings
we can also use the static method string.Format to format the string , we wrap the paramters in
{} represented as numbers then the second argument in the string.format would contain the repective
variables or strings that we want to include in our expression 
interpolated strings - we use interpolated expressions to construct a string


object - this is the base entity for all value types , it means it is possible to conevert any variable
of a value type eg int or float to an object type

interfaces - earlier it was said a class could implement an interfacef, meaning it can implement all
methods, prperties , events and indexers


//Delegates
//The delegate reference type allows specification of the required signature of a method
//The delegate could be instantiated, as well as invoked, 


//input and output
you can read data from the standard input and output stream ReadLine and ReadKey 