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



