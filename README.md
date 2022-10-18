## BankMachineProject
A small app for handling bank errends

# Usage
The app works around letting the user check account balances and transfer money between accounts.
The user also have the possiblity to withdraw money from the account of their choosing.

# Build
I've choose to use a mixed structure of for-loops and arrays to handle user data. This because of the simpicity of using arrays as this project-
only have 5 permanent users. This works as far so long we don't want a dynamic banking program.


I have also choosen to create seperat methods for each function and tool to make it easier to understand and read the code.


# Improvments
Alot of things in the program can ofcourse be improved from whatever the user handling is built to how I take in user input.
One big problem is tha need to move the arrays and username though out the entire program on each method to be able to use calls to other methods.
This is from when starting the program and having a plan that slowly evolves and changes and after a bit there is to much to change and update to make the program work.
A better planing is always needed when It comes to development on your own.
Also some varible names should be more self-explainatory though some of these don't really make sense to someone else except myself.
Nested methods and condition statements is also a problem here and there in the program which could be made better with more planing and time.
This could be improved though either making more methods that are dynamic and can be reused multiple times instead of focusing on just the one part in the program.
If we would like to have a more dynamic program we would instead implement the usage of databases and classes to make user handling expandable and easier to understand.

# Reflection

You've choosen to save and handle the user data and accounts with 2 2D arrays. This becuase it is an easy method to use because you can see each element from the start. 
Although this is not a dynamic method to handle the userdata it works to reach the project requirments. In another cas I would like to instead use a class to handle the user username and pincode which are then stored in a list of class-objects for each user or use a database for an even more powerful way to handle users and accounts.
Though this would require more knowledge of programming than what I currently posses.

I've used a series of for-loops to get and select each and also specific elements of both my 2D arrays. This becuase I feel it is easier to use for-loops for index finding in arrays than while or foreach. I would use a foreach pehaps when handling a List<T> instead of an array.

With the for-loops I have also controlled the flow by using if-statements for event-handling and some user input. I've also used a switch to handle the Menu input becuase I feel like its a more stylish and proper way to handle things like a menu.
I've choosen if-statements were I want to check multiple conditions inside the same parameter list like if(username = true && userpin == true). This is useful as we 
decress the amount of code needed spread out and make more narrow methods.

In my login method I've choosen to let the user enter a username and pincode and save those to different variables. I then takes these variables and run them trough a algorythm of for-looops comparing each element in my 2D array that handles the userino. To be sure it was sucessful I return 2 bools with either true or false one for 
the username and one for the pin. I*ve choosen to return 2 as I want to be able to tell the user if the username or pincode was false, Something I haven't actually used in the program as i forgot to add it :).

The login structure could be alot better, from handling the accounts in a database and only using sql quarrys to check the input against the database but as for now this works.

I think the menu display looks ok and tells the user the important information about the program.

In the menu i let the user decide where to go. I send the accounts, alluser and current user to each method the user can acess to be able to display and handle them like updating the account balance or just to check which user is logged in and display accounts for only that user.
  
This was one of the harder problems i hade with the program as the parameter lists went on to be a bit longer than I intended. One way to solve this would be to have the useraccounts and userinfo as global varibles which would make the whole process of handling alot easier but alot more unsafe as usually you don't want have full access to things like accounts and usernames and pincodes. This is why I have decided to make both of them at the start of the program in the Main()-Method.
  
 There is not much to say about the method to show the user accounts except since I've used 2D arrays I'm limited to a number of indexslots making it a bit difficult to have each user have a different amount of accounts as I have 1 user with 1 account visablee but he still takes up one slot in the memore as he has a second "hidden" account. One solve for this would be using jagged arrays instead if we are used to use arrays that being said. As a jagged array can vary in size for each induvidual place in the array.
  
  The hardest part to create was the transfer money method as I needed to check for the amount of accounts the user hade, if they had enought money for the transfer, exception handling as we are dealing with user input and also update the array that handles accounts and update on the right place. I've chosen to put some of these problems in separate methods as I find the code being to nested or unreadable if I hade it all in 1 method. this ofcourse came with the issue of having to send all elements in the parameter lists again to each of the new methods to be able to run for-loops and check conditions on each of the problems.
 Also this could been made alot simpler with the use of a database as we kan check for a key in the DB and then compare each row for the specific user we want to handle.
  
 One thing I would change if I re-wrote the entire program is to implement more itteration control for things like when the user picks accounts to transfer to/from and the amount and if they enter wrong they are sent back to the menu. Here instead I could've added a loop that returns true if one of the parts are incorrectly input and lets the user try againn without sending them back to the menu but also have a way to return to the menu so they don't get stuck in a loop of trying again until they enter the right things.
  
 Also one big improvment I could make if I made the program again is to plan ahead alot more. As I can see how one day I solve a problem one way and the next I solve another problem in another way. This makes the code non-consistant and some parts are repetative and the code could been scaled down. 
 
