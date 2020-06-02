*** Settings ***
Library                             SeleniumLibrary

*** Keywords ***
Begin Webtest
    Open Browser                    about:blank  ${BROWSER}

Page Loaded
    Load Page
    Verify Rental Page Loaded

Load Page
    Go To                           ${URL}


Verify Rental Page Loaded
    Location Should Be       http://rental15.infotiv.net/


Log Out
    Click Button               //*[@id="logout"]



Continue To The Car Page
    Click Button                   //*[@id="continue"]


Verify Car Page Loaded
    Location Should Be            http://rental15.infotiv.net/webpage/html/gui/showCars.php


Choosing A Car
    Click Button                    //*[@id="bookQ7pass5"]

Verify Credit Card Page Open
    Location Should Be              http://rental15.infotiv.net/webpage/html/gui/confirmBook.php


Inserting Card Number
    [Arguments]                     ${credit_card}
    Input Text                      id:cardNum  ${credit_card}

Inserting Name
    [Arguments]                     ${full_name}
    Input Text                      id:fullName     ${full_name}

Inserting Credit Card Date And Cvc
    [Arguments]                     ${cvc}
    Input Text                      id:cvc   ${cvc}

Confirm Book
    Click Button                    //*[@id="confirm"]

Verify That The Book Is Completed
    Location Should Contain         updateAvailability

Check My Page
    Click Button                   //*[@id="mypage"]

Confirm Book Exists
    Wait Until Page Contains        My bookings


Attempting Login
    [Arguments]                     ${username}         ${password}
    Input Text                      id:email            ${username}
    Input Text                      id:password         ${password}

Log in
    Click Button                    //*[@id="login"]

Create User Has Been Selected
    Selecting Create User
    Verify Create User Loaded

Selecting Create User
    Click Button                    //*[@id="createUser"]



Verify Create User Loaded
    Wait Until Page Contains       Create a new user


Invalid data has been inserted
    [Arguments]                     ${username}         ${last_name}   ${phone_number}   ${e_mail}  ${confirm_email}  ${password}  ${confirm_password}
    Input Text                      id:name             ${username}
    Input Text                      id:last             ${last_name}
    Input Text                      id:phone            ${phone_number}
    Input Text                      id:emailCreate      ${e_mail}
    Input Text                      id:confirmEmail     ${confirm_email}
    Input Text                      id:passwordCreate   ${password}
    Input Text                      id:confirmPassword  ${confirm_password}

Valid data has been inserted
    [Arguments]                     ${username}         ${last_name}   ${phone_number}   ${e_mail}  ${confirm_email}  ${password}  ${confirm_password}
    Input Text                      id:name             ${username}
    Input Text                      id:last             ${last_name}
    Input Text                      id:phone            ${phone_number}
    Input Text                      id:emailCreate      ${e_mail}
    Input Text                      id:confirmEmail     ${confirm_email}
    Input Text                      id:passwordCreate   ${password}
    Input Text                      id:confirmPassword  ${confirm_password}

Creation Has Been Confirmed
    Click Button                    //*[@id="create"]

The Login Page Should Be Open
    [Arguments]                     ${username}
   Wait Until Page Contains         You are signed in as ${username}

An Error Should Show Up
    Wait Until Page Contains        That E-mail is already taken

End webtest
    Close Browser