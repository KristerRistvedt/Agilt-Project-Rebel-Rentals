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

TEst the test
    [Documentation]             bruh
    [Tags]                      bruh2

    Page Loaded
    Verify Rental Page Loaded
    Press Ships
    Find Images





