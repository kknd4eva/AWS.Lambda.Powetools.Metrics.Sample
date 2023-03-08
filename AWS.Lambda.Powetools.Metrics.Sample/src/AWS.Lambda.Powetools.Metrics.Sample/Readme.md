# Lambda Powertools metrics sample
This project provides a simple example of how to use the Lambda Powertools metrics module.
The project is written in .NET6, and uses the AWS SDK for .NET to interact with AWS services.

## Use

Just deploy the project to your AWS account (to save on time, just use Visual Studio 'publish to AWS Lambda' feature), and invoke the function. 
The function will create a CloudWatch metric, and send a sample metric to it. To invoke, open curl or Postman (or your fave REST client), and send a POST request to the function's endpoint.



