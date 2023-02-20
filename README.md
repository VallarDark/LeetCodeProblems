# LeetCodeProblems  
A little project with LeetCode problems solutions  
  
Here we have custom testing system for each problem and some architecture to simplify adding new solutions  
Where you should override Solution() method for ProblemBased class  
![image](https://user-images.githubusercontent.com/65999338/220156955-f82065cb-8c5b-44b2-b9eb-4eb565d96965.png)  
  
And add new test cases in constructor in _ProblemTestCases list  
![image](https://user-images.githubusercontent.com/65999338/220157119-fae34f85-9d4b-4c7b-8171-25c7272f737e.png)  
  
And also you should write your own problem Input/Output classes because all problems have different input/output data  
![image](https://user-images.githubusercontent.com/65999338/220157796-f99adc1a-35ca-4877-bbe4-2ffde2a16832.png)  
![image](https://user-images.githubusercontent.com/65999338/220157914-63628948-5396-4ddc-b601-a3b89112ac46.png)  
To be sure that your tests works in right way you should implement IEquatable<Output> for your custom output class.  
