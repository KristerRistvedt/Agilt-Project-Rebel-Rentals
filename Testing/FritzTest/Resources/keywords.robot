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
    Location Should Be       https://localhost:44353/

Press Ships
    Click Element           Xpath://div/div/ul[2]/li[2]/a
    Location Should Be      https://localhost:44353/Ships

Find Images
    Page Should Contain Image   Xpath://div/main/table/tbody/tr[2]/td[1]/img
    Page Should Contain Image   Xpath://div/main/table/tbody/tr[1]/td[1]/img

Enter details
    Click Element                Xpath://div/main/table/tbody/tr[1]/td[6]/a[2]
    Location Should Be          https://localhost:44353/Ships/Details?id=2

More Find Images
    Page Should Contain Image   Xpath://div/main/div[1]/img


Place An Order
    Click Element               Xpath://div/main/table/tbody/tr[1]/td[6]/form/button
    Click Element               Xpath://div/main/table/tbody/tr[2]/td[6]/form/button

Go To Order Page
    Click Element               Xpath://nav/div/div/ul[1]/li[1]/a/img
    Location Should Be          https://localhost:44353/ShoppingCartOverview

End webtest
    Close Browser

