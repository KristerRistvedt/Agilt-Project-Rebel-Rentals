*** Settings ***
Library                             SeleniumLibrary
Library                             String
*** Keywords ***
Generate Phonenumber
    ${PHONENUMBER}=     Generate Random String  7   [NUMBERS]
    Set Global Variable     ${PHONENUMBER}

Generate Email
    ${RANDOMSTRING}=   Generate Random String   6   [NUMBERS]abcdef
    Set Global Variable     ${RANDOMSTRING}

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
    Location Should Be          https://localhost:44353/Ships/Details?id=1

More Find Images
    Page Should Contain Image   Xpath://div/main/div[1]/img


Place An Order
    Click Element               Xpath://div/main/table/tbody/tr[1]/td[6]/form/button
    Click Element               Xpath://div/main/table/tbody/tr[2]/td[6]/form/button

Go To Order Page
    Click Element               Xpath://nav/div/div/ul[1]/li[1]/a/img
    Location Should Be          https://localhost:44353/ShoppingCartOverview

Check If Travelspot Is Present
    Wait Until Page Contains    Big, bright, beautiful spiral, Messier 106 dominates this cosmic vista. The nearly two degree wide telescopic field of view looks toward the well-trained constellation Canes Venatici, near the handle of the Big Dipper. Also known as NGC 4258, M106 is about 80,000 light-years across and 23.5 million light-years away, the largest member of the Canes II galaxy group. For a far far away galaxy, the distance to M106 is well-known in part because it can be directly measured by tracking this galaxy's remarkable maser, or microwave laser emission. Very rare but naturally occurring, the maser emission is produced by water molecules in molecular clouds orbiting its active galactic nucleus. Another prominent spiral galaxy on the scene, viewed nearly edge-on, is NGC 4217 below and right of M106. The distance to NGC 4217 is much less well-known, estimated to be about 60 million light-years, but the bright spiky stars are in the foreground, well inside our own Milky Way galaxy. Even the existence of galaxies beyond the Milky Way was questioned 100 years ago in astronomy's Great Debate.

Check If Travelspot Is Not Present
    Page Should Not Contain     Big, bright, beautiful spiral, Messier 106 dominates this cosmic vista. The nearly two degree wide telescopic field of view looks toward the well-trained constellation Canes Venatici, near the handle of the Big Dipper. Also known as NGC 4258, M106 is about 80,000 light-years across and 23.5 million light-years away, the largest member of the Canes II galaxy group. For a far far away galaxy, the distance to M106 is well-known in part because it can be directly measured by tracking this galaxy's remarkable maser, or microwave laser emission. Very rare but naturally occurring, the maser emission is produced by water molecules in molecular clouds orbiting its active galactic nucleus. Another prominent spiral galaxy on the scene, viewed nearly edge-on, is NGC 4217 below and right of M106. The distance to NGC 4217 is much less well-known, estimated to be about 60 million light-years, but the bright spiky stars are in the foreground, well inside our own Milky Way galaxy. Even the existence of galaxies beyond the Milky Way was questioned 100 years ago in astronomy's Great Debate.




Register an account
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Input Text                          xpath://*[@id="Input_PhoneNumber"]          073${PHONENUMBER}
        Click Element                       xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains            Register confirmation
        Click Element                       xpath://*[@id="confirm-link"]
        Wait Until Page Contains            Thank you for confirming your email


Register an account FAil
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Input Text                          xpath://*[@id="Input_PhoneNumber"]          ${INVALID_PHONE_NUMBER1}
        Click Element                       xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains            Only Swedish phone numbers are accepted at the moment


Register an account Fail Again
        Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
        Wait Until Page Contains            Create a new account
        Wait Until Element Is Visible       xpath://*[@id="Input_Email"]
        Input Text                          xpath://*[@id="Input_Email"]        ${RANDOMSTRING}@email.com
        Input Text                          xpath://*[@id="Input_Password"]        ${PASSWORD}
        Input Text                          xpath://*[@id="Input_ConfirmPassword"]      ${PASSWORD}
        Input Text                          xpath://*[@id="Input_PhoneNumber"]          ${INVALID_PHONE_NUMBER2}
        Click Element                       xpath://html/body/div/main/div/div[1]/form/button
        Wait Until Page Contains            The value '07681999999' is not valid for Phone Number.


Log In
    Click Element                           Xpath://nav/div/div/ul[1]/li[3]/a
    Input Text                              Xpath://*[@id="Input_Email"]            Bruh.Bruh@Bruh.com
    Input Text                              xpath://*[@id="Input_Password"]         Bruh1234!
    Click Element                           Xpath://*[@id="account"]/div[5]/button

Input Number
    Click Element                       xpath://html/body/header/nav/div/div/ul[1]/li[2]/a
    Wait Until Page Contains            Manage your account
    Input Text                          xpath://*[@id="Input_PhoneNumber"]      073${PHONENUMBER}       True
    Click Button                        xpath://*[@id="update-profile-button"]
    Wait Until Page Contains            Your profile has been updated


Input Number Fail
    Click Element                           Xpath://nav/div/div/ul/li[2]/a
    Input Text                              Xpath://*[@id="Input_PhoneNumber"]      ${INVALID_PHONE_NUMBER1}        True
    Click Element                           Xpath://*[@id="update-profile-button"]
    Wait Until Page Contains                Invalid phone number


Input Number Fail But Again
    Click Element                           Xpath://nav/div/div/ul/li[2]/a
    Input Text                              Xpath://*[@id="Input_PhoneNumber"]      ${INVALID_PHONE_NUMBER2}        True
    Click Element                           Xpath://*[@id="update-profile-button"]
    Wait Until Page Contains                Invalid phone number


Log Out Failsafe
    Click Element                           Xpath://nav/div/div/ul[1]/li[3]/form/button

Translate Sith
    Click Translator
    Choose sith

Click Translator
    Click Element                           Xpath://nav/div/div/ul[2]/li[4]/a

Choose Sith
    Click Element                           Xpath://*[@id="SelectedLanguage"]
    Click Element                           Xpath://*[@id="SelectedLanguage"]/option[1]
    Input Text                              Xpath://*[@id="TextToTranslate"]        Hello
    Click Element                           Xpath://div/main/div/form/button
    Wait Until Page Contains                Hello
Choose Gungan
    Click Element                           Xpath://*[@id="SelectedLanguage"]
    Click Element                           Xpath://*[@id="SelectedLanguage"]/option[2]
    Input Text                              Xpath://*[@id="TextToTranslate"]        Hello
    Click Element                           Xpath://div/main/div/form/button
    Wait Until Page Contains                Hidoe

Choose Yoda
    Click Element                           Xpath://*[@id="SelectedLanguage"]
    Click Element                           Xpath://*[@id="SelectedLanguage"]/option[3]
    Input Text                              Xpath://*[@id="TextToTranslate"]        Hello
    Click Element                           Xpath://div/main/div/form/button
    Wait Until Page Contains                Force be with you

Overload Check
    Wait Until Page Contains                Too many requests, try again later.


Click Chuck Norris Quotes
    Click Element                           Xpath://div/div/ul[2]/li[5]/a
    Location Should Be                      https://localhost:44353/ChuckNorris
    Wait Until Page Contains                If you're sad and need a Chuck Norris quote to cheer you up, click this button:

Change Quote
    Click Element                           Xpath://div/main/form/button
    Page Should Not Contain                 If you're sad and need a Chuck Norris quote to cheer you up, click this button:


End webtest
    Close Browser

