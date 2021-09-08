# Word Sequence Finder

## Description
This app reads text, and prints out 100 most common words in descending order.

## How to run
[Install dotnet 5.0, click here!](https://dotnet.microsoft.com/download)

### Commands
Run these commands in this directory:

```
dotnet build
```

to test:
```
dotnet test
```

to run:
```
dotnet run .\texts\moby-dick.txt .\texts\brothers-karamazov.txt
```

or use executable:
```
cat .\texts\moby-dick.txt | .\bin\Debug\net5.0\New-Relic-Code-Challenge.exe
.\bin\Debug\net5.0\New-Relic-Code-Challenge.exe .\texts\moby-dick.txt
```

## How this works

This app processes all input into one string, modifies string to remove punctuation, make lowercase, etc. Then goes through that entire string, processing 3 word sequences and adding them to a dictionary. This dictionary is sorted by descending value at the end, and then read from to produce the output.

This should handle unicode correctly, and removes punctuation such that `whale-men` becomes `whalemen` and `whale’s` becomes `whales`
## Improvements

We could break input text into multiple chunks, and process all those chunks into the dictionary simultaneously taking advantage of multiple threads.

Add more tests

## Execution Time

### Passing in file name:

```
145 ms moby dick
90 ms bros
208 ms both
```
stdin:
```
269 ms moby dick
````