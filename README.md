# GeekZapper
This project is about learning how to parallel program in C#. It will create two threads to watch for two unwanted bundleware programs: 
GeekBuddy and NowUSeeItPlayer. When it sees any of their processes it will automatically kill them and return to searching for them 
(they pop up on a timer). Our AV program wasn't getting rid of them because of hidden registry files, hidden auto-installers, or something,
so I thought I would learn something new while I try to figure out how to get rid of the bundleware.
# Future
1. Event Handlers - For now, I'm content with my twin thread while loops killing the unwanted processes whenever they pop up. In the 
future I would like to learn about how to make the program just listen for the process to start up. I know there are event handlers in 
C# and C#'s Process class itself. 
2. Performance Testing - I'm also curious to see the performance of two while loops running at the same time, especially compared to 
using event handlers. 
3. Gui/Background Mode - It would be nice to have a GUI as well as a background mode.
4. Tracking - I really want to be able to track everything these processes touch inside the OS, as well as anything leaving out network.
C++ would probably be a better language choice for that but I really want to see if I can do it in C#.
5. Above all, I really want to get deep into multi-threading with C# along with getting familiar with the Process class.
