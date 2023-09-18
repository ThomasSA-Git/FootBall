(endte med ikke at bruge de her forslag)

To generate a CSV file for a football league with 12 teams playing 22 rounds followed by a split into upper and lower fractions, each playing 10 additional rounds internally, you can structure the matches like this. Here's a sample CSV file for the first 22 rounds:

csv
Copy code
Home Team,Away Team,Score
LBK,OB,1-0
BIF,FCK,2-1
RFC,AaB,0-2
FCH,FCN,1-1
AGF,SJE,3-0
EFC,VB,1-2
LBK,FCH,2-0
OB,EFC,1-1
BIF,RFC,3-1
FCK,AGF,2-2
AaB,VB,1-0
FCN,SJE,0-2
LBK,AaB,1-2
OB,RFC,0-0
BIF,SJE,2-1
FCK,VB,3-0
FCH,AGF,1-1
FCN,EFC,2-2
LBK,RFC,2-1
OB,AGF,1-1
BIF,EFC,0-1
FCK,SJE,2-2
AaB,FCN,1-0
This represents the first 22 rounds of matches where each team plays against every other team once. After these 22 rounds, you can create two separate CSV files for the upper and lower fractions with 6 teams each. Here's an example of how you can structure the next 10 rounds for the upper fraction:

csv
Copy code
Home Team,Away Team,Score
LBK,BIF,2-0
FCK,RFC,3-1
AaB,FCH,1-0
OB,FCN,2-2
AGF,EFC,2-1
SJE,VB,0-1
LBK,AGF,1-1
FCK,AaB,2-0
RFC,OB,1-2
BIF,SJE,0-1
LBK,OB,3-0
FCK,EFC,2-1
RFC,AGF,1-1
AaB,VB,2-0
FCH,SJE,1-1
FCN,BIF,1-2
You would create a similar CSV file for the lower fraction. In total, you would have 32 rounds of matches (22 for the initial round-robin, and 10 for the upper and lower fractions). This example demonstrates how to structure the data, but you can generate additional rounds using a program or script to automate the process.