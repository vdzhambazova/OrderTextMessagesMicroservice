# OrderTextMessagesMicroservice
An ASP.NET Core API microservice to keep customers of a delivery company up to date with their order through text messages. 

##### 1. Contains of two Controllers. 
###### Restaurant controller handles get requests to get all restaurants.
###### Messages controller handles posting order, sending message to user and adding it to db and getting a log object containing the last 50 sent messages and the messages which do not have status delivered.


##### 2. Db of choice is SqLite because it is lightweight and self-contained and it is a quick solution for a db server to exist inside the container along with the api

##### 3. By building the Dockerfile and running the Docker image, the app can be containerized and can be run on any machine