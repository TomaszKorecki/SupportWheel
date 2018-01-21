# Assumed requirements

Program is able to generate and show support shifts for next several days for the team of employees. Both the number of days and amount of employees are the configuration parameters in the appsettings.json file in the API project.

Moreover, once shift plan is generated, it's kept in the memory. For this purpose Memory Cache was used. It would allow to setup whole application on the company server and show the shift plan to everyone interested. 

The whole shift plan could be re calculated using button RELOAD on the main page of the application. 
