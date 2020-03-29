# kattis-CSharp

## Problem A
The city’s local subway service S.L., Super Lag, are currently being blamed that their displays, showing the expected wait time until the next train arrives, are faulty. Too many commuters have the experience of coming to the subway station, and then having to wait many more minutes than the display showed when they got there.
The American Commuter Movement and the International Commuting Peoples’ Community have had it with this. Especially Johan, a young student, who has decided to investigate this matter further. Johan went to one of the stations, and studied the behaviour of the displays. Each time the display showed a new number, Johan carefully measured the number of seconds that passed from that moment until the train arrived. As soon as that train left again, he did the same thing for the next train and so on. He remembered all the displayed minutes, and the wait time for each such in seconds. Although Johan has a very good memory, he does not know what to do with his measurements. He needs your help!

Your task is to help Johan calculate the average length of an S.L. minute (the length of a minute according to the display). You may assume that when the display shows a new number M, the expected S.L. wait time in that moment is exactly M minutes.

### Input
The first line contains an integer 1≤N≤1000 – the number of observations Johan did. The following N lines contain two positive integers M≤60 and S≤3600 – the number of minutes displayed, and the number of seconds Johan had to wait for his train.

### Output
Output should consist of a single real number: the average length of an S.L. minute, measured in real minutes. A relative or absolute error of at most 10−7 will be considered correct. If the average length of an S.L. minute is shorter than or equal to a normal minute, print the message "measurement error" instead.


#### Sample 1

##### Input
```
1
1 61
```
##### Output
```
1.016666667
```

#### Sample 2
##### Input
```
3
5 560
10 600
2 264
```
##### Output
```
1.396078431
```

## Problem B
The king in Utopia has died without an heir. Now several nobles in the country claim the throne. The country law states that if the ruler has no heir, the person who is most related to the founder of the country should rule.

To determine who is most related we measure the amount of blood in the veins of a claimant that comes from the founder. A person gets half the blood from the father and the other half from the mother. A child to the founder would have 1/2 royal blood, that child’s child with another parent who is not of royal lineage would have 1/4 royal blood, and so on. The person with the most blood from the founder is the one most related.

### Input
The first line contains two integers, N (2≤N≤50) and M (2≤M≤50). The second line contains the name of the founder of Utopia.

Then follows N lines describing a family relation. Each such line contains three names, separated with a single space. The first name is a child and the remaining two names are the parents of the child.

Then follows M lines containing the names of those who claim the throne.

All names in the input will be between 1 and 10 characters long and only contain the lowercase English letters ‘a’–‘z’. The founder will not appear among the claimants, nor be described as a child to someone else.

### Output
A single line containing the name of the claimant with most blood from the founder. The input will be constructed so that the answer is unique.

The family relations may not be realistic when considering sex, age etc. However, every child will have two unique parents and no one will be a descendent from themselves. No one will be listed as a child twice.

#### Sample 1

##### Input
```
4 5
andrew
betsy andrew flora
carol andrew betsy
dora andrew carol
elena andrew dora
carol
dora
elena
flora
gloria
```
##### Output
```
elena
```

#### Sample 2
##### Input
```
9 2
edwardi
charlesi edwardi diana
philip charlesi mistress
wilhelm mary philip
matthew wilhelm helen
edwardii charlesi laura
alice laura charlesi
helen alice bernard
henrii edwardii roxane
charlesii elizabeth henrii
charlesii
matthew
```
##### Output
```
matthew
```
