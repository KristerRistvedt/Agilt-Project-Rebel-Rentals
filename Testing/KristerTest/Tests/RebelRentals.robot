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
${SEARCH_TERM} =                Rebel Rentals
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

Switch to contact page
        Go to Web Page
        Wait Until Page Contains    ${SEARCH_TERM}
        Click Element               xpath://html/body/header/nav/div/div/div/a[2]
        Wait Until Page Contains    Contact Us

Switch to home page
        Click Element               xpath://*[@id="company-logo"]
        Wait Until Page Contains    NASA's Daily Recommended Tourist Location

Register an account
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[1]
        Wait Until Page Contains            Create a new account.
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      0731234567
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://html/body/div[1]/main/div/div/form/button
        Wait Until Page Contains            Click here to confirm your account
        Click Element                       xpath://*[@id="confirm-link"]
        Wait Until Page Contains            Thank you for confirming your email

Register an account fail
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[1]
        Wait Until Page Contains            Create a new account.
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}fuck@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      0731234567
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://html/body/div[1]/main/div/div/form/button
        Wait Until Page Contains            Profanity not allowed
        Page Should Not Contain             Register confirmation

Login to account
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[2]
        Wait Until Page Contains            Use a local account to log in.
        Input Text                          xpath://*[@id="Input_Email"]        ${USERNAME}
        Input Text                          xpath://*[@id="Input_Password"]     ${PASSWORD}
        Click Element                       xpath://html/body/div[1]/main/div/div/section/form/div[5]/button
        Wait Until Page Contains            Profile

Login to and logout from the site
        Login to account
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/form/button
        Wait Until Page Contains            You have successfully logged out of the application.

Go to register page from login page
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[2]
        Wait Until Page Contains            Use a local account to log in.
        Click Element                       xpath://html/body/div[1]/main/div/div/section/form/div[6]/p[2]/a
        Wait Until Page Contains            Create a new account.

Go to Ships page
        Click Element                       xpath://html/body/header/nav/div/div/div/a[3]
        Wait Until Page Contains            Max. population

Add ships to cart
        Click Button                        xpath://html/body/div[1]/main/table/tbody/tr[2]/td[6]/form/button
        Click Button                        xpath://html/body/div[1]/main/table/tbody/tr[4]/td[6]/form/button

Go to cart
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[1]/a
        Wait Until Page Contains            Death Star
        Wait Until Page Contains            Star Destroyer

Remove ship from cart
        Click Button                        xpath://html/body/div[1]/main/table/tbody/tr[2]/td[4]/form/button
        Wait Until Page Does Not Contain    Star Destroyer

Checkout with current cart
        Click Element                       xpath://html/body/div[1]/main/div/a
        Wait Until Page Contains            Order summary

See if picture and text regarding vacation exists
        Wait Until Page Contains            NASA's Daily Recommended Tourist Location
        Wait Until Page Contains Element    xpath://*[@id="apod-image"]
        Element Should Be Visible           xpath://html/body/div[1]/main/div[2]/p

See if a new picture and text regarding vacation exists another day
        Wait Until Page Contains            NASA's Daily Recommended Tourist Location
        Wait Until Page Does Not Contain    Radio, The Big Ear, and the Wow! Signal

Go to profile and change phone number
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a
        Wait Until Page Contains            Manage your account
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      073${PHONENUMBER}       True
        Click Button                        xpath://*[@id="update-profile-button"]
        Wait Until Page Contains            Your profile has been updated

Register an account with invalid phonenumber format
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[1]
        Wait Until Page Contains            Create a new account.
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      999999999999
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://html/body/div[1]/main/div/div/form/button
        Wait Until Page Contains            is not valid for Phone Number
        Page Should Not Contain             Register confirmation

Go to profile and change phone number with invalid phonenumber formats
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a
        Wait Until Page Contains            Manage your account
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      999999999999       True
        Click Button                        xpath://*[@id="update-profile-button"]
        Wait Until Page Contains            Invalid phone number

Go to contact page and input the neccessary contact information in the appropriate fields
        Click Element                       xpath://html/body/header/nav/div/div/div/a[2]
        Wait Until Page Contains            Contact Us
        Input Text                          xpath://*[@id="NameField"]      Autotest${RANDOMSTRING}
        Input Text                          xpath://*[@id="EmailField"]     ${RANDOMSTRING}@email.com

Compose message to support staff and click the send button
        Input Text                          xpath://*[@id="MessageField"]       ${RANDOMSTRING}${RANDOMSTRING}${RANDOMSTRING}
        Click Button                        xpath://html/body/div[1]/main/form/div[4]/button
        Wait Until Page Contains            A support member will get back to you as soon as possible

See if Galactic Translator page exists by clicking its link in the navbar
        Click Element                       xpath://*[@id="navbarDropdownMenuLink2"]
        Click Element                       xpath://html/body/header/nav/div/div/div/div/div/a[1]
        Wait Until Page Contains            Enter text to translate:

See if you can choose a language from a dropdown menu and enter text to translate
        Click Element                       xpath://*[@id="SelectedLanguage"]
        Click Element                       xpath://html/body/div[1]/main/div/form/select/option[2]
        Input Text                          xpath://*[@id="TextToTranslate"]        I have told you before that this is not a language!     True
        Textarea Should Contain             xpath://*[@id="TextToTranslate"]        I have told you before that this is not a language!

Click on the translate button and make sure the inputted text gets translated
        Click Button                        xpath://html/body/div[1]/main/div/form/button
        Page Should Not Contain             Too many requests

Go to the Galactic Translator Page
        See if Galactic Translator page exists by clicking its link in the navbar

Go to the Galactic Translator Page and enter text to translate to sith
        Go to the Galactic Translator Page
        Input Text                          xpath://*[@id="TextToTranslate"]        Sith shall conquer all.     True
        Textarea Should Contain             xpath://*[@id="TextToTranslate"]        Sith shall conquer all.

Change language to Gungan and change the text to be translated
        Click Element                       xpath://*[@id="SelectedLanguage"]
        Click Element                       xpath://html/body/div[1]/main/div/form/select/option[2]
        Input Text                          xpath://*[@id="TextToTranslate"]        I have told you before that this is not a language!     True
        Textarea Should Contain             xpath://*[@id="TextToTranslate"]        I have told you before that this is not a language!

Change language to Yoda
        Click Element                       xpath://*[@id="SelectedLanguage"]
        Click Element                       xpath://html/body/div[1]/main/div/form/select/option[3]
        Input Text                          xpath://*[@id="TextToTranslate"]        I have told you before that this is not a language!     True
        Textarea Should Contain             xpath://*[@id="TextToTranslate"]        I have told you before that this is not a language!

Click on the translate button
        Click Button                        xpath://html/body/div[1]/main/div/form/button

Click on the translate button and make sure nothing is translated
        Click Button                        xpath://html/body/div[1]/main/div/form/button
        Page Should Contain                 Too many requests

Check if an Order Page exists and is accessible through the shoppingcart
        Checkout with current cart
        Element Text Should Not Be          xpath://html/body/div[1]/main/p        Total cost: 0

Go to the Order Summary Page by finalizing an order
        Check if an Order Page exists and is accessible through the shoppingcart
        Click Button                        xpath://html/body/div[1]/main/table[2]/tbody/tr/td[2]/form/button
        Wait Until Page Contains            Back to List
        Element Text Should Be              xpath://html/body/div[1]/main/h1       Summary

Go back to the Cart and check if the list has been cleared
        Click Element                       xpath://html/body/div[1]/main/div/a
        Wait Until Page Contains            Max. population
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[1]/a
        Wait Until Page Contains            Shopping Cart
        Page Should Not Contain             Checkout

Go to the Order Summary Page
        Checkout with current cart
        Element Text Should Not Be          xpath://html/body/div[1]/main/p        Total cost: 0

Clear the order list and return to the cart to check if it is cleared
        Click Button                        xpath://html/body/div[1]/main/table[2]/tbody/tr/td[1]/form/button
        Wait Until Page Contains            NASA's Daily Recommended Tourist Location
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[1]/a
        Wait Until Page Contains            Shopping Cart
        Page Should Not Contain             Checkout

Check if ship costs are listed in swedish crowns as default
        Wait Until Page Contains            5000 kr

Go to Profile Page and change the currency
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a
        Wait Until Page Contains            Manage your account
        Click Button                        xpath://html/body/div[1]/main/div/div/div[2]/div/div/div/form/button
        Wait Until Element Is Visible       xpath://*[@id="Id"]
        Click Element                       xpath://*[@id="Id"]
        Click Element                       xpath://html/body/div[1]/main/div/div/div[2]/div/div/div/form/select/option[99]
        Click Button                        xpath://html/body/div[1]/main/div/div/div[2]/div/div/div/form/button
        Wait Until Page Contains            Current Currency:
        Wait Until Page Contains            Japanese Yen

Check if currency is now in Japanese Yen
        Element Should Contain              xpath://html/body/div[1]/main/table/tbody/tr[1]/td[5]       ¥
        Element Should Not Contain          xpath://html/body/div[1]/main/table/tbody/tr[1]/td[5]      kr

Register an account as support staff
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[1]
        Wait Until Page Contains            Create a new account.
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_PhoneNumber"]      0731234567
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element                       xpath://*[@id="RoleSupport"]
        Wait Until Element Is Visible       xpath://*[@id="Input_SupportPassword"]
        Input Text                          xpath://*[@id="Input_SupportPassword"]      AllasMamma
        Click Element                       xpath://html/body/div[1]/main/div/div/form/button
        Wait Until Page Contains            Click here to confirm your account
        Click Element                       xpath://*[@id="confirm-link"]
        Wait Until Page Contains            Thank you for confirming your email

Check if you can reach the support staff page with your new account
        Click Element                       xpath://*[@id="company-logo"]
        Wait Until Page Contains            NASA's Daily Recommended Tourist Location
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[2]
        Wait Until Page Contains            Use a local account to log in.
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_Password"]     ${PASSWORD}
        Click Element                       xpath://html/body/div[1]/main/div/div/section/form/div[5]/button
        Wait Until Page Contains            Profile
        Click Element                       xpath://*[@id="navbarDropdownMenuLink"]
        Click Element                       xpath://html/body/header/nav/div/div/ul/li[2]/div/a[2]
        Wait Until Page Contains Element    xpath://html/body/div[1]/main/table[1]/tbody/tr/td[1]/div/a

End Agile Project Test
        Close Browser

*** Test Cases ***
User can access RebelRental page
    [Documentation]             Test: The user should be able to access the RebelRentals page.
    [Tags]                      Access
    Go to Web Page

User can switch pages in the navbar
    [Documentation]             Test: The user should be able to switch pages from the header menu.
    [Tags]                      Header      Pages       Navbar
    Go to Web Page
    Switch to contact page
    Switch to home page

User can create an account
    [Documentation]             Test: The user should be able to create an account.
    [Tags]                      Account     Navbar
    Go to Web Page
    Generate Email
    Register an account

User can not create an account using profanity
    [Documentation]             Test: The user should not be able to create an account using profanity in username/email.
    [Tags]                      Account     Profanity_Filter        Invalid
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
    [Tags]                      Account     Shopping_Cart    Add_Products       Navbar
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
    [Tags]                      Account     Phone_Number        Profile     Navbar
    Go to Web Page
    Generate Email
    Register an account
    Generate Phonenumber
    Login to account
    Go to profile and change phone number

User should not be able to add a phonenumber at registration or add/change phonenumber after registration with invalid phonenumber formats
    [Documentation]             Test: The user should not be able to add their phonenumber at registration of their account or after in their profile if they use invalid phonenumber formats.
    [Tags]                      Account     Phone_Number    Invalid
    Go to Web Page
    Generate Email
    Register an account with invalid phonenumber format
    Login to account
    Go to profile and change phone number with invalid phonenumber formats

User should be able to reach a Contact page from the navbar and send a message/an email to support staff
    [Documentation]             Test: The user should be able to reach a contact page from the navbar, and by entering name, email and message into the appropriate fields send a message and/or email to support staff by then clicking a button.
    [Tags]                      Support     Contact_Page    Message     Email       Navbar
    Go to Web Page
    Generate Email
    Go to contact page and input the neccessary contact information in the appropriate fields
    Compose message to support staff and click the send button

User should be able to reach a Galactic Translator Page from the navbar and enter relevant information
    [Documentation]             Test: The user should be able to reach a Galactic Translator Page and choose language and enter the text to be translated.
    [Tags]                      Navbar      Translate
    Go to Web Page
    See if Galactic Translator page exists by clicking its link in the navbar
    See if you can choose a language from a dropdown menu and enter text to translate

User should be able to use the Galactic Translator Page to translate text into 3 different languages
    [Documentation]             Test: By using the Galactic Translator Page the user should be able to translate text into the three existing languages in the dropdown menu.
    [Tags]                      Navbar      Translate       Translate_Coverage
    Go to Web Page
    Go to the Galactic Translator Page and enter text to translate to sith
    Click on the translate button and make sure the inputted text gets translated
    Change language to Gungan and change the text to be translated
    Click on the translate button and make sure the inputted text gets translated
    Change language to Yoda
    Click on the translate button and make sure the inputted text gets translated

User should not be able to translate anything more than five times during a certain period of time
    [Documentation]             Test: After translating something/anything on the translate page five times, an error message should appear instead of a translation.
    [Tags]                      Navbar      Translate       Invalid
    Go to Web Page
    Go to the Galactic Translator Page and enter text to translate to sith
    Click on the translate button
    Change language to Gungan and change the text to be translated
    Click on the translate button
    Change language to Yoda
    Click on the translate button
    Change language to Gungan and change the text to be translated
    Click on the translate button
    Change language to Yoda
    Click on the translate button
    Change language to Gungan and change the text to be translated
    Click on the translate button
    Change language to Yoda
    Click on the translate button
    Change language to Gungan and change the text to be translated
    Click on the translate button and make sure nothing is translated

User should be able to access the Order Page through the shoppingcart after adding ships to it
    [Documentation]             Test: The user reacher an order page through the shopping cart, and sees a small summary of the items of said cart and total cost.
    [Tags]                      Shopping_Cart       Order_Page      Place_An_Order
    Go to Web Page
    Login to account
    Go to Ships page
    Add ships to cart
    Go to cart
    Check if an Order Page exists and is accessible through the shoppingcart

User should be able to access a Order Summary Page through the Order Page by finalizing the users order
    [Documentation]             Test: The user reacher a more detailed order summary through the order page, and sees more detailed information about items in the shoppingcart.
    [Tags]                      Shopping_Cart       Order_Page      Place_An_Order       Summary_Page
    Go to Web Page
    Login to account
    Go to Ships page
    Add ships to cart
    Go to cart
    Go to the Order Summary Page by finalizing an order

Users order list on the Order Page should have been cleared by finalizing the order
    [Documentation]             Test: The users order should be cleared after having seen the Order Summary after finalizing their order.
    [Tags]                      Shopping_Cart       Order_Page      Place_An_Order
    Go to Web Page
    Login to account
    Go to Ships page
    Add ships to cart
    Go to cart
    Go to the Order Summary Page by finalizing an order
    Go back to the Cart and check if the list has been cleared

User should be able to remove their shopping cart items by clearing their order list
    [Documentation]             Test: The users order should be able to be cleared by clicking a button on the Order Page.
    [Tags]                      Shopping_Cart       Order_Page      Place_An_Order
    Go to Web Page
    Login to account
    Go to Ships page
    Add ships to cart
    Go to cart
    Go to the Order Summary Page
    Clear the order list and return to the cart to check if it is cleared

User should be able to see a default currency in swedish crowns on the ships page
    [Documentation]             Test: The ships page should have ship costs in swedish crowns as a default.
    [Tags]                      Ship_Page      Currency
    Go to Web Page
    Go to Ships page
    Check if ship costs are listed in swedish crowns as default

User should be able to change currency in their profile and see it changed on the ships page
    [Documentation]             Test: The ships page should have ship costs in whichever currency the user has chosen as their currency on their profile page.
    [Tags]                      Ship_Page      Currency     Profile
    Go to Web Page
    Login to account
    Go to Profile Page and change the currency
    Go to Web Page
    Go to Ships page
    Check if currency is now in Japanese Yen

User can create an account as support staff and go to the support page when logged in said account
    [Documentation]             Test: After creating a new account flagged as support staff, a support page link should appear in the account dropdown menu in the navbar.
    [Tags]                      Account     Support
    Go to Web Page
    Generate Email
    Register an account as support staff
    Check if you can reach the support staff page with your new account

