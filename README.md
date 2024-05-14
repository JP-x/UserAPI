# UserAPI
Consume data from ```http://jsonplaceholder.typicode.com``` and return different user data.

## User

### GET /UserList
```https://localhost:7216/User/UserList```  
Returns a list of users including their id, username, email, and city.  
**Response:**
```
[
    {
        "id": 1,
        "username": "Bret",
        "email": "Sincere@april.biz",
        "city": "Gwenborough"
    },
    {
        "id": 2,
        "username": "Antonette",
        "email": "Shanna@melissa.tv",
        "city": "Wisokyburgh"
    }
]
```

### GET  /Metrics
```https://localhost:7216/User/Metrics```  
Returns a list of all users including their id, numberOfPosts, and numberOfTodos.  
**Response:**
```
[
    {
        "id": 1,
        "numberOfPosts": 10,
        "numberOfTodos": 20
    },
    {
        "id": 2,
        "numberOfPosts": 10,
        "numberOfTodos": 20
    }
]
```
### GET /Commenters
```https://localhost:7216/User/Commenters```
Returns a list of all users including their id, username, and commenter emails.  
**Response:**
```
[
    {
        "id": 1,
        "username": "Bret",
        "commenters": [
            "Eliseo@gardner.biz",
            "Jayne_Kuhic@sydney.com",
            "Nikita@garfield.biz"
        ]
    },
    {
        "id": 2,
        "username": "Antonette",
        "commenters": [
            "Laurie@lincoln.us",
            "Abigail.OConnell@june.org",
            "Laverne_Price@scotty.info"
        ]
    }
]
```