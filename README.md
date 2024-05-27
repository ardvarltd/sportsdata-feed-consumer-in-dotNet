B2B Kafka feed
==============

## Base requirements
* net 8.0

### Set up project
* [install docker](https://docs.docker.com/engine/install/)
* [install docker-compose](https://docs.docker.com/compose/install/)

### Run the application to read from AVRO topics
* In order to run the application using kafka prod run "docker-compose -f docker-compose-prod.yаml up"  in the terminal
* After a successful build you will start seeing data coming
* Run one container: `docker-compose run --rm <service-name>`

### Development
# Add application settings 
      "KafkaSettings": {
        "Server": "",
        "SchemaRegistryUrl": "",
        "Key": "",
        "Secret": "",
        "GroupId": "",
        "SecurityProtocol": "",
        "SaslMechanism": ""
      }
    
      "EventSettings": {
        "Topic": ""
      }
    
      "MarketSettings": {
        "Topic": ""
      }
    
      "SettlementSettings": {
        "Topic": ""
      }
  
# Launch container
docker-compose run --rm <service-name> bash

# Inside the container
cd /var/www/app && composer install
bin/console $BUILDER_TYPE --break
```
