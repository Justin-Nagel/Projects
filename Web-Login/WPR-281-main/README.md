# WPR 281

## Design
https://www.figma.com/file/OUzLa4qzDuwTyp8NWQkZZB/Untitled?type=whiteboard&node-id=0%3A1&t=6lAzR4TfgLrhNPc7-1

- [x] Basic Layout(Conrad)
- [x] Person object(JJ)
- [x] lettersOnly(Justin) 
- [x] nubersOnly(Justin) 
- [x] emailValid(Justin) 
- [x] randomRefrence(Dylan) 
- [x] resefForm(Conrad)
- [x] formValid(JJ)
- [x] noSpecialCharceters (Justin - Added this to lettersOnly function)
- [x] Redisplay Info(Conrad&JJ)

Justin: Instead of adding a new function to test specifically for special characters, I just applied the same method for numbers in the lettersOnly function but for special characters. If you prefer to do a separate function, all you have to do is copy the specialArray and loops from lettersOnly and put them in the specialCharacter function.
One more thing, I kept the '-' sign as some people's names have that in.
Changed numbersOnly function a bit to include test for special characters

JJ: I added a noSpecialCharecters function since I think the name and surname should not be allowed to have something like @ signs and so on

~~Side note: I think the globalPerson should be changed because all of them say: "globalPerson.**first-name**" meaning first-name has the value of email, last-name, ID and so on.~~  *(fixed)*

~~Justin: I have completed the lettersOnly and numbersOnly functions, I have kept the console.log() if you want to see how it gets the values (not important can remove if needed.)~~
~~P.S. I wanted to test the notSpecialCharacters built-in function, not sure if it works because of the site no longer working, if prefer to do our own functions can just delete it.~~
~~I already stated on Whatsapp that the site no longer functions for some reason, or at least the functions no longer execute but the blur thing still does... not sure how to fix - please look into this.~~
