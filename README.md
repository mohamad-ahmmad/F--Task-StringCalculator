# StringCalculatorTemplate
Here is the small app I wanted you to do.
I would like to see you do it in F#.
You can also do it twice once with a language you are comfortable with and once with F#.

This is probably the best resource on it.
http://fsharpforfunandprofit.com/

I personally like kit eason 
https://www.pluralsight.com/courses/fsharp-jumpstart 

but this course is good as well
https://www.pluralsight.com/courses/fsharp-fundamentals

I would also like for you to push your code to github.
Please commit your code after each step.
I want to see the progress of the code.
Do not just commit after step 9 please.
If you have any questions please feel free to email me.

side note: 
if you want extra points DO NOT use regex (regular expressions)

```
1.Create a simple String calculator with a method int Add(string numbers)
                The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
                Start with the simplest test case of an empty string and move to 1 and two numbers

2.Allow the Add method to handle an unknown amount of numbers

3.Allow the Add method to handle new lines between numbers (instead of commas).
                the following input is ok:  “1\n2,3”  (will equal 6)
                the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)

4.Support different delimiters
                to change a delimiter, the beginning of the string will contain a separate line that looks like this:  
                 “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
                the first line is optional. all existing scenarios should still be supported

5.Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.if there are multiple negatives, show all of them in the exception message

6.Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2

7.Delimiters can be of any length with the following format:  “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6

8.Allow multiple delimiters like this:  “//[delim1][delim2]\n” for example “//[*][%]\n1*2%3” should return 6.

9.make sure you can also handle multiple delimiters with length longer than one char
```
