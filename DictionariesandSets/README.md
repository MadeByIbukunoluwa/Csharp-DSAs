#Hashtables
allows mapping keys to particular values
One of the most important assumptions of the hash table is the very possibility of
very fast lookup for a value based on a key which should be a O(1) operation

for this reason , if you wan to tfind the value of a key you don't need to iterate through all items
in the collection because you can just use the hash function to easily locate a proper bucket and get the value 

the role of the hash function is very critical and ideally it should generate a unique result for all keys , if the
same result is generated for more then one keys , it will result in a hash collision 

There are two hash table related classes HashTable and Dictionary

Hashtable - non generic
Ditionary - generic

the hashtable stores a collection of paris where each pari is a DictionaryEntry instance

the performance of getting a value of an element, adding a new element, or updating an existing one,
is approaching the O(1) operation.

The variable used in the loop , when you are looping through a dictionary is a KeyValuePair

## Sorted Dictionary
normally , if we need to present data from the collection sorted by keys , we need to sort them
prior to presentation
we can use this to keep keys sorted all the time 


## drawbacks
despite the automatic sorting advantages , the SortedDictionary class has performance drawbacks as
retrieval , insertion and removal are O(logn) operations instead of O(n)
As you can see, choosing a proper data structure is not an easy task and you should think carefully
about the scenarios in which particular data structures will be used and take into account the both pros and cons.


## Hashsets
These data structures just store keys without values

A set is a collection of distinct objects without duplicated
elements and without a particular order.
Therefore, you can only get to know whether a given element is in the set or not.
The sets are strictly connected with the mathematical models and operations, such as
union, intersection, subtraction, and symmetric difference.
A set can store various data , such as string or integer values, you can also create
a set with instances of a user defined class , as well as add or remove elements
from the set at any time


## Sorted Sets
if a set can be defined as a collection of unique elements with no particular order, then how are there sorted sets??
Well its simple, they are not really sorted sets but a combination of HashSets and Sorted Lists, it can be found
in the systems.collections.generic namespace
the sorted sets can be used if you want to have a collection of distinct objects without duplicated elements
