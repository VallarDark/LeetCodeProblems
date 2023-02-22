# LeetCodeProblems  
  
A little project with LeetCode problems solutions  
  
Here we have custom testing system for each problem and some architecture to simplify adding new solutions  
Where you should override <b>Solution()</b> method for <b>ProblemBased</b> class  
  
![image](https://user-images.githubusercontent.com/65999338/220156955-f82065cb-8c5b-44b2-b9eb-4eb565d96965.png)  
  
   
And add new test cases in constructor in <b>_ProblemTestCases</b> list  
  
![image](https://user-images.githubusercontent.com/65999338/220157119-fae34f85-9d4b-4c7b-8171-25c7272f737e.png)  
   
   
And also you should write your own problem <b>Input/Output</b> classes because all problems have different input/output data  
   
![image](https://user-images.githubusercontent.com/65999338/220447316-e4e08611-83b0-4c75-9b36-98dae8ba1cf4.png)
    
    
To be sure that your tests works in right way you should implement<b> IEquatable<Output></b> for your custom <b>Output</b> class.  

If you have more then 1 solution you can test them by adding <b>Diagnoser : DiagnosableBase<Diagnoser></b> with some benchmarks 
and implementing <b>IDiagnosable</b> interface for your current task  
   
![image](https://user-images.githubusercontent.com/65999338/220447089-116cc8e2-7a8a-4a48-8fb3-861b4f8e13b2.png)

To see your benchmark testing result in right order you should override <b>ToString()</b> method for your <b>Input</b> class
   
