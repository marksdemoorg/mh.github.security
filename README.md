Pull the code from the Github repository
    --Provide path details

Run docker-compose build
Run docker-compose up

Check docker desktop for the port the container is running in

Use ngrok to allow Github webhooks to connect to the service
    -- ngrok http https://localhost:63332 -host-header="localhost:63332"

Open the orginazation webhooks
https://github.com/organizations/marksdemoorg/settings/hooks

Edit the Code scanning alert webhook

Set the Playload URL to the correct address based of the gronk setting

Open the sample project application in Github
https://github.com/marksdemoorg/mh.github.user.service

Edit one of the .cs files, add an unused variable like
    var myVar123 = "Hello";

Save the file

Go to the build workflow and wait for its completion
https://github.com/marksdemoorg/mh.github.user.service/actions/workflows/CI-Workflow.yml

Open the webhooks recent deliveries tab
https://github.com/organizations/marksdemoorg/settings/hooks/349975437?tab=deliveries

Look for a delivery for the code issue in the push


Open the service app Swagger page
https://5240-24-18-16-110.ngrok.io/swagger/index.html



