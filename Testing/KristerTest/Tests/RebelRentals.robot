*** Settings ***

Documentation       This is a test suite around an agile projects website made with Razor Pages
Library             SeleniumLibrary
Library             String
Test Setup          Begin Agile Project Page Test
Test Teardown       End Agile Project Test

*** Variables ***

${BROWSER} =                    firefox
${URL} =                        https://localhost:44353
${SEARCH_TERM} =                RebelRentals
${LOGIN} =                      xpath://*[@id="login"]
${USERNAME} =                   test@mctest.se
${PASSWORD} =                   Testyness@10

*** Keywords ***

Generate Email
    ${RANDOMSTRING}=   Generate Random String   6   [NUMBERS]abcdef
    Set Global Variable     ${RANDOMSTRING}

Begin Agile Project Page Test
        Open Browser                about:blank     ${BROWSER}

Go to Web Page
        Go To                       ${URL}
        Wait Until Page Contains    ${SEARCH_TERM}

Switch to privacy page
        Go to Web Page
        Click Element               xpath://html/body/header/nav/div/div/ul[2]/li[2]/a
        Wait Until Page Contains    Privacy Policy

Switch to home page
        Click Element               xpath://html/body/header/nav/div/div/ul[2]/li[1]/a
        Wait Until Page Contains    Welcome

Register an account
        Click Element               xpath://html/body/header/nav/div/div/ul[1]/li[1]/a
        Wait Until Page Contains    Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                  xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                  xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                  xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Click Element               xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains    Register confirmation

End Agile Project Test
        Close Browser

*** Test Cases ***
User can access RebelRental page
    [Documentation]             Test: The user should be able to access the RebelRentals page
    [Tags]                      Access
    Go to Web Page

User can switch pages in header menu
    [Documentation]             Test: The user should be able to switch pages from the header menu
    [Tags]                      Header      Pages
    Go to Web Page
    Switch to privacy page

User can create an account
    [Documentation]             Test: The user should be able to create an account
    [Tags]                      Account
    Go to Web Page
    Generate Email
    Register an account


