*** Settings ***

Documentation  This is some basic info about the whole test suite
Resource       C:/Users/fritz/PycharmProjects/RebelRentals/Resources/keywords.robot
Library        SeleniumLibrary

Test Setup     Begin web test
Test Teardown  End webtest

*** Variables ***
${BROWSER} =    chrome
${URL} =    https://localhost:44353/
${PASSWORD} =   Bruh1234!
${INVALID_PHONE_NUMBER1} =   076819999
${INVALID_PHONE_NUMBER2} =   07681999999



*** Test Cases ***




WEB-89 Test 3
    [Documentation]           This is the test case that is going to test if you can change your already exisisting phone number and that yu cant use more than 10 numbers
    [Tags]                    Test WEB-89-3
    Page Loaded
    Log In
    Generate Phonenumber
    Input Number
    Input Number Fail
    Input Number Fail But Again




WEB1-25 test
    [Documentation]            This is the test case that is going to test the functionality of the list of ships.
    [Tags]                     Test WEB1-25

    Page Loaded
    Verify Rental Page Loaded
    Press Ships
    Find Images
    Enter Details
    More Find Images



WEB1-87 Test
    [Documentation]           This is the test case that us going to test the functionality of the NASA API
    [Tags]                    Test WEB-87

    Page Loaded
    Verify Rental Page Loaded
    Check If Travelspot Is Not Present

WEB1-42 Test
    [Documentation]            This is the test case that is going to test the functionality of the order page.
    [Tags]                     Test WEB-42

    Page Loaded
    Verify Rental Page Loaded
    Press Ships
    Place An Order
    Go To Order Page
    Page Should Contain       A-Wing
    Page Should Contain       Death Star




WEB-89 Test
    [Documentation]           This is the test case that us going to test the functionality of the phone number validator
    [Tags]                    Test WEB-89-1
    Page Loaded
    Verify Rental Page Loaded
    Generate Phonenumber
    Generate Email
    Register An Account

WEB-89 Test 2
    [Documentation]           This is the test case that us going to test that the phone number validator takes exactly 10 numbers
    [Tags]                    Test WEB-89-2

    Page Loaded
    Verify Rental Page Loaded
    Generate Email
    Register An Account Fail
    Register An Account Fail Again







