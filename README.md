# Assumed requirements

Program is able to generate and show support shifts for next several days for the team of employees. Both the number of days and amount of employees are the configuration parameters in the appsettings.json file in the API project.

Moreover, once shift plan is generated, it's kept in the memory. For this purpose Memory Cache was used. It would allow to setup whole application on the company server and show the shift plan to everyone interested. 

The whole shift plan could be re calculated using button RELOAD on the main page of the application. 


# Extendable algorithm

Algorithm which randomly selects the employees for the next day support was written to be extedable as much as possible. Two attached app_image shows the slight difference between first and the second - extended algorithm. 

Requirements did not directly said that the employee could not take more support in a week then two. Such result is visible on the image the app_image.png. Extended algorithm includes all of the previous selection and tries to do much more fairly querying. Exmployee should not have been selected for the second time if there is someone who tries to hide himself from the adorable supporting and have not yet been selected for his duty. The result is visible on the app_image_2.png