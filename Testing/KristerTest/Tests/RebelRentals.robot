*** Settings ***

Documentation       This is a test suite around an agile projects website made with Razor Pages.
Library             SeleniumLibrary
Library             String
Library             DateTime
Test Setup          Begin Agile Project Page Test
Test Teardown       End Agile Project Test

*** Variables ***

${BROWSER} =                    firefox
${URL} =                        https://localhost:44353
${SEARCH_TERM} =                RebelRentals
${LOGIN} =                      xpath://*[@id="login"]
${USERNAME} =                   test1@mctest1.se
${PASSWORD} =                   Testyness@10

*** Keywords ***

Generate Email
    ${RANDOMSTRING}=   Generate Random String   6   [NUMBERS]abcdef
    Set Global Variable     ${RANDOMSTRING}

Generate Phonenumber
    ${PHONENUMBER}=     Generate Random String  7   [NUMBERS]
    Set Global Variable     ${PHONENUMBER}

Begin Agile Project Page Test
        Open Browser                about:blank     ${BROWSER}

Go to Web Page
        Go To                       ${URL}
        Wait Until Page Contains    ${SEARCH_TERM}

Switch to privacy page
        Go to Web Page
        Click Element               xpath://html/body/header/nav/div/div/ul[2]/li[3]/a
        Wait Until Page Contains    Privacy Policy

Switch to home page
        Click Element               xpath://html/body/header/nav/div/div/ul[2]/li[1]/a
        Wait Until Page Contains    NASA's Daily Recommended Tourist Location

Register an account
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      0731234567
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains            Register confirmation
        Click Element                       xpath://*[@id="confirm-link"]
        Wait Until Page Contains            Thank you for confirming your email

Register an account fail
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}fuck@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      0731234567
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains            Profanity not allowed
        Page Should Not Contain             Register confirmation

Login to account
        Wait Until Page Contains            Login
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[3]/a
        Input Text                          xpath://*[@id="Input_Email"]        ${USERNAME}
        Input Text                          xpath://*[@id="Input_Password"]     ${PASSWORD}
        Click Element                       xpath://html/body/div/main/div/div[1]/section/form/div[5]/button
        Wait Until Page Contains            ${USERNAME}

Login to and logout from the site
        Wait Until Page Contains            Login
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[3]/a
        Input Text                          xpath://*[@id="Input_Email"]        ${USERNAME}
        Input Text                          xpath://*[@id="Input_Password"]     ${PASSWORD}
        Click Element                       xpath://html/body/div/main/div/div[1]/section/form/div[5]/button
        Wait Until Page Contains            ${USERNAME}
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[3]/form/button
        Wait Until Page Does Not Contain    ${USERNAME}

Go to register page from login page
        Wait Until Page Contains            Login
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[3]/a
        Wait Until Page Contains            Use a local account to log in
        Click Element                       xpath://html/body/div/main/div/div[1]/section/form/div[6]/p[2]/a
        Wait Until Page Contains            Create a new account

Go to Ships page
        Click Element                       xpath://html/body/header/nav/div/div/ul[2]/li[2]/a
        Wait Until Page Contains            Max. population

Add ships to cart
        Click Button                        xpath://html/body/div/main/table/tbody/tr[2]/td[6]/form/button
        Click Button                        xpath://html/body/div/main/table/tbody/tr[4]/td[6]/form/button

Go to cart
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[1]/a
        Wait Until Page Contains            Death Star
        Wait Until Page Contains            Star Destroyer

Remove ship from cart
        Click Button                        xpath://html/body/div/main/table/tbody/tr[2]/td[10]/form/button
        Wait Until Page Does Not Contain    Star Destroyer

Checkout with current cart
        Click Element                       xpath://html/body/div/main/div/a

See if picture and text regarding vacation exists
        Wait Until Page Contains            NASA's Daily Recommended Tourist Location
        Wait Until Page Contains Element    xpath://html/body/div/main/div[2]/img
        Wait Until Page Contains Element    xpath://html/body/div/main/div[2]/p
        Element Should Be Visible           xpath://html/body/div/main/div[2]/img
        Element Should Be Visible           xpath://html/body/div/main/div[2]/p

See if a new picture and text regarding vacation exists another day
        Wait Until Page Contains            NASA's Daily Recommended Tourist Location
        Wait Until Page Does Not Contain                 Radio, The Big Ear, and the Wow! Signal

Go to profile and change phone number
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Manage your account
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      073${PHONENUMBER}       True
        Click Button                        xpath://*[@id="update-profile-button"]
        Wait Until Page Contains            Your profile has been updated

Register an account with invalid phonenumber format
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      999999999999
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains            is not valid for Phone Number
        Page Should Not Contain             Register confirmation

Go to profile and change phone number with invalid phonenumber formats
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Manage your account
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      999999999999       True
        Click Button                        xpath://*[@id="update-profile-button"]
        Wait Until Page Contains            Invalid phone number


End Agile Project Test
        Close Browser

*** Test Cases ***
User can access RebelRental page
    [Documentation]             Test: The user should be able to access the RebelRentals page.
    [Tags]                      Access
    Go to Web Page

User can switch pages in header menu
    [Documentation]             Test: The user should be able to switch pages from the header menu.
    [Tags]                      Header      Pages
    Go to Web Page
    Switch to privacy page
    Switch to home page

User can create an account
    [Documentation]             Test: The user should be able to create an account.
    [Tags]                      Account
    Go to Web Page
    Generate Email
    Register an account

User can not create an account using profanity
    [Documentation]             Test: The user should not be able to create an account using profanity in username/email.
    [Tags]                      Account     Profanity_Filter
    Go to Web Page
    Register an account fail

User can login with registered credentials and logout
    [Documentation]             Test: The user should be able to reach a login page with a button/link. The user should then be able to login with the credentials stored at the registration and log out.
    [Tags]                      Account     Login       Logout
    Go to Web Page
    Login to and logout from the site

User can reach register page from the login page
    [Documentation]             Test: The user should be able to reach the register page from the login page if they do not have an account.
    [Tags]                      Account     Referal
    Go to Web Page
    Go to register page from login page

User can add ships/products to their shopping cart and remove them
    [Documentation]             Test: The user should be able to add and remove products from their cart, and reach said cart.
    [Tags]                      Account     Shopping_Cart    Add_Products
    Go to Web Page
    Login to account
    Go to Ships page
    Add ships to cart
    Go to cart
    Remove ship from cart

User can see a vacation recommendation through NASA pictures
    [Documentation]             Test: The user should be able to see a picture and some text regarding places on earth and/or in space to visit for vacation while renting a ship.
    [Tags]                      Home_Page       Vacation        NASA
    Go to Web Page
    See if picture and text regarding vacation exists

User should see a different vacation recommendation every day
    [Documentation]             Test: The user should be able to see a different picture and text, regarding places on earth and/or in space to visit for vacation while renting a ship, each new day. Depends on external website, change test manually each time the test is run on a new day.
    [Tags]                      Home_Page       Vacation        NASA        New
    Go to Web Page
    See if a new picture and text regarding vacation exists another day

User should be able to add a phonenumber at registration or add/change phonenumber after registration
    [Documentation]             Test: The user should be able to add their phonenumber for ease of contact with support staff, at registration of their account or after due to an older version of the website not containing phone numbers or if the user needs to change their number.
    [Tags]                      Account     Phone_Number
    Go to Web Page
    Generate Email
    Register an account
    Generate Phonenumber
    Login to account
    Go to profile and change phone number

User should not be able to add a phonenumber at registration or add/change phonenumber after registration with invalid phonenumber formats
    [Documentation]             Test: The user should not be able to add their phonenumber at registration of their account or after in their profile if they use invalid phonenumber formats.
    [Tags]                      Account     Phone_Number
    Go to Web Page
    Generate Email
    Register an account with invalid phonenumber format
    Login to account
    Go to profile and change phone number with invalid phonenumber formats