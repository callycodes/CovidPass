# CovidPass
 Covid vaccine and test history tracker, theoretical platform to determine if a person should be travelling busing test and vaccine results, could be used by businesses, the government, border controls, police etc. Dotnet core API and Vue.js, Typescript front-end.

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

I have used Postgres for my database server, and utilised Postico to graphically view and edit these.

Below shows each table name, with their fields and respective (key) and data type.

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


## Improvements
This is my first time using Typescript, and although it compiles, I have had to play with the ESlint rules to ignore/suppress some warnings. I had a lot of trouble understanding if my ESLint configuration was even being considered, and hot reloading can be very tempermental. 

It's also been a while since I've made a project incorportating a C# backend, so using .NET Core 5 came with a few learning curves, however I have all the endpoints I need for this project. It could be extended to contain all your typical methods such as GetAll/Put/Delete/Post etc for Test and Vaccine Controllers, however for this project they weren't needed.

## Palette

I used coolors.co for the colour palette generation - awesome tool! https://coolors.co/

## Future Plans

This project works on the basis it would be used to register vaccine and test results. For this, the dashboard would be split into adminstration panels, some accessible by people with specific credentials, another only accessible by a user via a Mobile App.

If the government, test centres and vaccine centres all used a central system like this, we could have an extremely easy way of tracking whether somebody should be travelling or not. This is not just useful for determining if a person is eligible to travel, but also for visiting the cinema, restaurants, activities and even public transport.

