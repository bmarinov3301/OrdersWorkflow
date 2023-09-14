<h1>Project configuration steps</h1>
<h2>Setting up AWS access (can be skipped if already done)</h2>

1. Create an AWS root account.
2. Creat an IAM user with console and programmatic access via the AWS console with the root account. Make sure to **save** the access and secret keys for the created user.
3. Configure AWS credentials with the access and secret keys for the IAM user created above and a region set to **eu-central-1** using the command **aws configure --profile theProfileName**

<h2>AWS infrastructure and project configuration</h2>

1. Install Amazon.Lambda.Tools Global Tools if not already installed.

```
    dotnet tool install -g Amazon.Lambda.Tools
```
2. Open AWS Management console
3. Create an IAM Role called **dev-bg-orders-workflow-role** with the following permissions:
    - AWSLambda_FullAccess
    - CloudWatchFullAccess
4. Open each project and:
    - Set properties in **aws-lambda-tools-defaults.json**:
        - set **profile** to the profile name configured in **Setting up AWS access Step 3**
        - set **region** to **eu-central-1**
    - Build project
    - Publish project:
      - Open a terminal in the project directory
      - Run **dotnet lambda deploy-function theFunctionName --function-role dev-bg-lambda-role**
5. Challenge: Open the AWS Management Console and create your Step Function using the Visual Workflow Designer and the above published Lambdas and the respective flow configurations. (Hint: **Task Token** needed for the **CallbackLambda payload** can be retrieved from the Step Function's **global context object** which can be accessed by using **"$$"** when specifying the state input structure inside the state configuration tab in **Visual Workflow Designer**)