# CovidPass
 Covid vaccine and test history tracker, theoretical platform to determine if a person should be travelling by countries border controls. Dotnet core API and Vue.js, Typescript front-end.

## Pages
**Home**
Not much purpose to the page other than informative, explanation on the purpose of the site etc.

**Profile**
![Image of Profile Page](https://i.imgur.com/UCohNl2.png)
Page where you can change settings in your profile, in real usage, this would be read-only and would be set up when you get your first covid test/vaccination as it  essentially provides identifying information.

**Passport**
![Image of Passport Page](https://i.imgur.com/WgRs1yn.png)
QR Code page - simple show and scan and this can be used to immediately link your profile to a scannable qr.

**Log Vaccine/Tests** (Theoretically only for GP's, Hospitals, Vaccination Centres to be able to use)
![Image of Log Page](https://i.imgur.com/a5Y5mK6.png)
Provides an interface to be able to log a persons recent vaccine or covid test and result. In the real world, this would be only utilised by NHS upon COVID test results, or a GP/Vaccination centre after a jab.

**Scan** (Theoretically only for border controls, government bodies to be able to use)
![Image of Scan Page](https://i.imgur.com/0ZCF14w.png)
Interface allowing a persons to search up the details of another person, retrieving their information, test and vaccine information. Would contain an option to connect to a camera to scan a qr code.

## Database Structure
**users**<br>
id *(PK)(int)*<br>
uid *(PK)(string)*<br>
firstName *(string)*<br>
lastName *(string)*<br>
dateOfBirth *(date)*<br>

**tests**<br>
id *(PK)(int)*<br>
userId *(FK)(string)*<br>
type *(string)*<br>
result *(bool)*<br>
dateOfTest *(date)*<br>

**vaccines**<br>
id *(PK)(int)*<br>
userId *(FK)(string)*<br>
type *(string)*<br>
count *(int)*<br>
dateOfVaccine *(date)*<br>

## Features

## Roles

## Future Plans


