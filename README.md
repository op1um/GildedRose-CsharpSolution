# GildedRose-CsharpSolution
My solution to the Gilded Rose refactoring kata

## Global thinking

To refactor this app I started to look at the code. I found two test classes that were useless and in the middle of 
the project. The UpdateQuality() method was very difficult to understand. The business says that the app works perfectly
today but since we can't test if it's true or not, the first step I took was to write unit tests to make sure I don't 
make any regression during the refactoring process.
I tried to have a clean code approach, by respecting the SOLID, KISS, DRY and SRP principles, In the end the nesting level 
is just 2 and the longest method is 20 lines (the item switch).

## The steps of the refactoring

1. Removal of the two useless test classes and creation of a proper unit test project in the solution.
2. Creation of unit test based on the requirements given by the business.
3. Creation of unit test based on code coverage to check every paths and particular cases.
4. With a code coverage of a 100% on the Gilded Rose class (the one containing the logic, the UpdateQuality() method) 
   I was now able to start the refactoring.
5. First, I tried to simplify the code by removing redundant calls or variables, I extracted the constant strings.
6. Then, I extracted the constant numbers such as maximumQuality wich is always 50 and the backstage passes thresholds.
7. I also extracted variables like the Items[i] that was called a lot of time in the UpdateQuality() mehtod.
8. Once this extractions were done, I began to simplify arithmetic, for example I changed : item.Quality = item.Quality + 1 
   into item.Quality++
9. Then, I simplified some tests by creating methods like IsAgedBrie(item).
10. Now that the code is simplified, I started to group related logic for each item type. At each step, I checked if my
   unit tests were still passing.
11. When I finished grouping related logic, I got rid of the old legacy code safely thanks to my unit tests.
12. With the code now clean and easy to understand we can implement the new behavior asked by the business. For this   
   I created 3 new unit tests and implemented the new conjured type.
13. I did some code cleaning like inverting ifs to reduce nesting, changing the for loop with a foreach
   creating some methods to avoid repeating myself like IncreaseQuality()
14. To go further in the refactoring and to respect the SOLID principle a lot more, I implemented a factory because I can't 
alter the Item class and I created 4 item type classes. Finally, I placed the business logic in each item type class and removed
unused code.

## How to compile and run this code

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

When you refactor it is hard to know when to stop. To go further, I could remove the switch from the updateQuality() method
and cast each item into the correct type directly in the constructor. Finally, if the Goblin allows me to alter the item class,
I could add the updateQuality() method and get rid of my factory.