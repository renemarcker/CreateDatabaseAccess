# CreateDatabaseAccess
This project is an assignment related to the back-end part of the Fullstack .Net Developer Accelerated Learning (Noroff). The focus is using SQL to create a database, manipulating SQL Server with C#, Git usage and pair programming. 

The whole description of the assignment can be found as **Assignment 2_CSharp_Data access with SQL Client.pdf**. 

## Appendix A
This part is all about creating a database (using SSMS) with content and setup the relationships.

![image](https://user-images.githubusercontent.com/15190773/220287685-cee99d31-c54f-4717-ade3-0d2ca299eda5.png)

### Relational Diagram
![RelationalDiagram](https://user-images.githubusercontent.com/15190773/220287736-6376ea04-145d-41b2-8957-924d52f39e6c.PNG)

### Scripts
| Name of Scripts | Description |
|-----------------|-------------|
|**01_dbCreate.sql**| Create the database (SuperheroesDB).|
|**02_tableCreate.sql**| Create the three tables in the database and setup the Primary Keys. |
|**03_relationshipsSuperheroAssistant.sql**| Using ALTER keyword the tables to add the Foreign Key and setup the constraint to configure the described relationship between superhero and assistant.|
|**04_relationshipSuperheroPower.sql**| Create an linking table meant between the **Superhero** and the **Power** tables. Then use the ALTER keyword to setup the Foreign Key constraints between the **Superhero** and the **Power**.  |
|**05_insertSuperhero.sql**| Insert three heroes into the **Superhero** table of the database. |
|**06_insertAssistants.sql**| Insert three assistants into the **Assistants** table of the database and which of the superheroes they assists. |
|**07_insertPowers.sql**| Insert four powers into the **Power** table of the database and assign powers to the superheroes. |
|**08_updateSuperhero.sql**| Update the data of one superhero, giving a new name. |
|**09_deleteAssistants.sql** | Delete one assistant from the **Assistants** table by name. |


## Appendix B
This part is to manipulating SQL Server data in Visual Studio using a library called SQL 
Client. For this part of the assignment, you are given a database to work with. It is called Chinook (Chinook_SqlServer_AutoIncrementPKs.sql).
### Customer Requirements

**Relevant information** : Id, first name, last name, country, postal code, phone number and email.

1. Read all the customers in the database, this should display their **Relevant information**:

2. Read a specific customer from the database (by Id), should display **Relevant information**.

3. Read a specific customer by name.

4. Return a page of customers from the database. This should take in limit and offset as parameters and make use of the SQL limit and offset keywords to get a subset of the customer data.

5. Add a new customer to the database. You also need to add only the fields listed above (our customer object).

6. Update an existing customer.

7. Return the number of customers in each country, ordered descending (high to low). i.e. USA: 13, … 

8. Customers who are the highest spenders (total in invoice table is the largest), ordered descending.

9. For a given customer, their most popular genre (in the case of a tie, display both).Most popular in this context means the genre that corresponds to the most tracks from invoices associated to that customer.


## Period of Project
The project ran between 20/2 - 23/2 2023




