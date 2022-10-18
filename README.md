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

