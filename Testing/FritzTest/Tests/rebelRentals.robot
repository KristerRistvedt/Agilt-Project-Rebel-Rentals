*** Settings ***

Documentation  This is some basic info about the whole test suite
Resource       C:/Users/fritz/PycharmProjects/RebelRentals/Resources/keywords.robot
Library        SeleniumLibrary

Suite Setup     Begin web test
Suite Teardown  End webtest

*** Variables ***
${BROWSER} =    chrome
${URL} =    https://localhost:44353/



*** Test Cases ***

WEB1-25 test
    [Documentation]            Yhis is the test case that is going to test the functionality of the list of ships.
    [Tags]                     Test WEB1-25

    Page Loaded
    Verify Rental Page Loaded
    Press Ships
    Find Images
    Enter Details
    More Find Images


WEB1-42 Test
    [Documentation]            Yhis is the test case that is going to test the functionality of the order page.
    [Tags]                     Test WEB-42

    Page Loaded
    Verify Rental Page Loaded
    Press Ships
    Place An Order
    Go To Order Page
    Page Should Contain       A-Wing
    Page Should Contain       Death Star






