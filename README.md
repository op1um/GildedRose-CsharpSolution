# GildedRose-CsharpSolution
My solution to the Gilded Rose refactoring kata

1. Global thinking

To refactor this app I started to look at the code. I found two test classes that were useless and in the middle of 
the project. The UpdateQuality() method was very difficult to understand. The business says that the app works perfectly
today but since we can't test if it's true or not, the first step I took was to write unit tests to make sure I don't 
make any regression during the refactoring process.
I tried to have a clean code approach, by respecting the KISS, DRY and SRP principles, In the end the nesting level 
is just 1 and the longest method is 9 lines.

2 The steps of the refactoring

a. Removal of the two useless test classes and creation of a proper unit test project in the solution.
b. Creation of unit test based on the requirements given by the business.
c. Creation of unit test based on code coverage to check every paths and particular cases.
d. With a code coverage of a 100% on the Gilded Rose class (the one containing the logic, the UpdateQuality() method) 
   I was now able to start the refactoring.
e. First, I tried to simplify the code by removing redundant calls or variables, I extracted the constant strings.
f. Then, I extracted the constant numbers such as maximumQuality wich is always 50 and the backstage passes thresholds.
g. I also extracted variables like the Items[i] that was called a lot of time in the UpdateQuality() mehtod.
h. Once this extractions were done, I began to simplify arithmetic, for example I changed : item.Quality = item.Quality + 1 
   into item.Quality++
i. Then, I simplified some tests by creating methods like IsAgedBrie(item).
j. Now that the code is simplified, I started to group related logic for each item type. At each step, I checked if my
   unit tests were still passing.
k. When I finished grouping related logic, I got rid of the old legacy code safely thanks to my unit tests.
l. With the code now clean and easy to understand we can implement the new behavior asked by the business. For this   
   I created 3 new unit tests and implemented the new conjured type.
m. Finally I did some ultimate code cleaning like inverting ifs to reduce nesting, changing the for loop with a foreach
   creating some methods to avoid repeating myself like IncreaseQuality()

3 How to compile and run this code

In order to compile and run this code, the Gilded Rose team gave us a program class to prompt the items states in the 
next 31 days.

* If you want to just compile the solution in Visual Studio :

click on the "Build" menu item and finally on "Build solution"

* If you want to run this code and see the output, you need to start without debugging.

Click on the "Debug" menu item and finally on "Start wihout debugging". You should be able to see the states of the
items in a console.

* You can also try to launch the unit tests to check if they are all passing :

In the solution explorer, right click on the GildedRoseTests project and choose the "Run Unit Tests" option.

4 Could I have gone any further in the refactoring

When you refactor it is hard to know when to stop. In the end I wanted to create a class for each item type
to really separate the logic but I think it would make the code harder to read and understand. That is why
I stopped here, For me I respected the principles stated earlier and the code is easy to read and adding new 
item types is safe and easy.