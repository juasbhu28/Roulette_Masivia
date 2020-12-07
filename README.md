## README Roulette_Masivia

##Api Roulette

Fortune wheel for the HH.js README Roulette.

### Features
  + Strong typing.
  + Swagger API Documentation
  + Dockerized
  + Versioning
  + horizontal scaling

#### Endpoint Swagger : https://localhost:5001/swagger/index.html

###  Endpoints

### ``` /v1/roulette/newgame  ```

Which returns an Guid:

``` 
{
  "id": "bc1b34ad-7bc6-4ed5-8777-723c348e5f0d"
}
```


### ``` /v1/roulette/getstatusgame/{rouletteId}  ```

Which returns a status:

``` 
{
  "status" : "open"  // (status ? "open" , "closed")
}
```

### ``` /v1/roulette/newbet  ```

Which returns a status:

``` 
{
  "status" : "Succes" || "Failed"
}
```


### ``` /v1/roulette/closegame/{rouletteId}  ```

Which returns a list of result:

``` 
{
   "bet_result":{
      "color":"black",
      "number":36
   },
   "winners_by_color":[
      {
         "playerId":"gamer1",
         "earn":"color" 
      },
      {
         "playerId":"gamer1",
         "earn":"color" 
      }
   ],
   "winners_by_number":[
      {
         "playerId":"gamer1",
         "earn":"color" 
      },
      {
         "playerId":"gamer1",
         "earn":"color" 
      }
   ]
}
```


### ``` /v1/roulette/getallgames  ```

Which returns a list of Roulettes games and statuses:

``` 
   [
      {
         "guid":"asdfa1",
         "status":"open"
      },
      {
         "guid":"asffa2",
         "status":"close"
      }
   ]
```
