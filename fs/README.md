# F# code

## chunker.fs
* break a list into chunks by a certain size

## Example
* Given a list such as: "one", "two", "three", "four", "five", "six".
* Break the list down into smaller chunks where the total length of the items strings is less than a given limit, in this case 10.
* The lists break down into: 
```
"one", "two" // 3 + 3 < 10
"three", "four" // 5 + 4 < 10
"five", "six" // 4 + 3 < 10
```

### Inspiration
I had a list of strings that was too long to use in a command, so I needed to break them up.
I wanted to do something more elegant than summing a mutable variable in a for loop.

This would be the usual imperative way (in C#):

```
const int limit = 10;
var list = new List<string> {"one", "two", "three", "four", "five", "six"};
var newList = new List<string>();
var sum = 0;
foreach (var item in list)
{
  sum += item.Length;
  if (sum >= limit) 
  {
    sum = 0;
    if (newList.Count() > 0)
    {
      newList.Add("-");
    }
  }
  newList.Add(item);
}
var output = string.Join(", ", newList.ToArray());
Console.WriteLine(output);
```
Some points:
* F# uses recursion, no loops. 
* F# has TCO, so recursion is safe, as long as the recursive call is the last one in the function.
* With F#, I mapped a list of lengths to assist with summing of string lengths.
* With F#, I created helper functions. I like that aspect of the language, where it's easy to create functions and then getting them to work together.
* Since C# uses a loop, it has the "end condition" built-in. In F# it requires more thought.
* C# can also use recursion, but there's a possibility of overflowing the stack.
