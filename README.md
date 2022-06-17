# Financial-Calculator
Takes financial questions as text and returns the result as number.
For now it only can solve present value (PV) and future value (FV) when accruing interest is only once in a year. 
Future value when accruing interest is more than once in a year is in development.

## Instruction

The PV and FV regex pattern looks like this: $20,000.00/$2000.00/€2000000 - There always has to be a currency in front of the number.
This won't work 20,000,00/20,000.00/20,000.00 dollars. 

The rate of return (r) value regex pattern looks like this: 8.8%/8,8 percent/8.8 %.

The num of periods (n - years) value regex pattern looks like this: 30 years/twenty years. 
!!!Important twenty (20) is the maximum number that can be writen with letters!!!

## Examples of working tests

### For FV when accruing interest is only once in a year:
Bob Terwilliger received $12,745 for his services as a financial consultant to the mayor's office of his hometown of Springfield. Bob says that his consulting work was his civic duty and that he should not receive any compensation. So, he has invested his paycheck into an account paying 3.91 percent annual interest and left the account in his will to the city of Springfield on the condition that the city could not collect any money from the account for 150 years. How much money will the city receive from Bob's generosity in 150 years?

The result from the application is: 4017367.51 and the answer from the quiz is 4,017,367.51

### For FV when accruing interest is more than once a year (compound interest monthly and quarterly):
Mr. X makes an initial investment of $ 10,000 for a period of 5 years. Find the value of the investment after the five years if the investment earns the return of 3 % compounded monthly.

The result from the application is: 11616.17 and the answer from the quiz is 11,616.17

### For PV:
Mr. X wants $10,000 after 3 years. The interest rate available on a specific investment, which he is interested in, is 4% per annum. How much he should invest today to receive the desired amount.

The result from the application is: 8889.96 and the answer from the quiz is 8,889.96





