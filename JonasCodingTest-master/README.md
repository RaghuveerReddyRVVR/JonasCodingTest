Q) Implement rest of Company controller functions, all the way down to data access layer
   CompanyController Methods Summary
Ans)
The CompanyController is responsible for handling CRUD operations related to company information. Below is a detailed summary of each method provided by this controller:

GET /api/company
Description: Retrieves a list of all companies in the system.
Return Type: Task<IEnumerable<CompanyDto>>
Response: A collection of company data transfer objects (DTOs) representing all companies.

GET /api/company/{companyCode}
Description: Retrieves details of a specific company based on the provided companyCode.
Return Type: Task<IHttpActionResult>
Response: A single CompanyDto object representing the company with the specified companyCode. Returns 404 Not Found if the company does not exist.
Example Response:
json
Copy code
{
  "CompanyCode": "COMP001",
  "CompanyName": "Tech Innovators",
  "OccupationName": "Software Development",
  "EmployeeStatus": "Active",
  "EmailAddress": "info@techinnovators.com",
  "PhoneNumber": "+123456789",
  "LastModifiedDateTime": "2024-08-27T14:35:45Z"
}
POST /api/company
Description: Adds a new company to the system.
Request Body: A CompanyDto object with the necessary company details.
Return Type: Task<IHttpActionResult>
Response: Returns 201 Created with the location of the newly created company. Returns 400 Bad Request if the input is invalid.
Example Request:
json
Copy code
{
  "CompanyCode": "COMP002",
  "CompanyName": "Future Tech",
  "OccupationName": "AI Research",
  "EmployeeStatus": "Active",
  "EmailAddress": "contact@futuretech.com",
  "PhoneNumber": "+987654321"
}
PUT /api/company/{companyCode}
Description: Updates the details of an existing company identified by companyCode.
Request Body: A CompanyDto object with updated company details.
Return Type: Task<IHttpActionResult>
Response: Returns 200 OK if the update is successful, or 404 Not Found if the company does not exist. Returns 400 Bad Request if the input is invalid.
Example Request:
json
Copy code
{
  "CompanyCode": "COMP001",
  "CompanyName": "Tech Innovators Ltd.",
  "OccupationName": "Software Development",
  "EmployeeStatus": "Active",
  "EmailAddress": "support@techinnovators.com",
  "PhoneNumber": "+123456789"
}
DELETE /api/company/{companyCode}
Description: Deletes a company from the system identified by companyCode.
Return Type: Task<IHttpActionResult>
Response: Returns 200 OK if the deletion is successful, or 404 Not Found if the company does not exist.
Example Response:
json
Copy code
{
  "Message": "Company successfully deleted."
}

Q) Change all Company controller functions to be asynchronous
Ans)
Done using async and await
Q) Create new repository to get and save employee information with the following data model properties:

* string SiteId,
* string CompanyCode,
* string EmployeeCode,
* string EmployeeName,
* string Occupation,
* string EmployeeStatus,
* string EmailAddress,
* string Phone,
* DateTime LastModified
Ans) Created

Q) Create employee controller to get the following properties for client side:

* string EmployeeCode,
* string EmployeeName,
* string CompanyName,
* string OccupationName,
* string EmployeeStatus,
* string EmailAddress,
* string PhoneNumber,
* string LastModifiedDateTime
Ans) Created

5) Add logger to solution and add proper error handling
Ans)Added
