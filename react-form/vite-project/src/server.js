const express = require('express')
const cors = require('cors')

const app = express()
app.use(cors())

app.use('/login', (req, res) => {
    res.send({
        token: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiIyYWE0ODZiYS05ZTU1LTRlMjUtODk2OS00ZmRmZDJlNDdlZTUiLCJpYXQiOiIzLzIwLzIwMjMgNzo1NTo0MyBBTSIsIlVzZXJOYW1lIjoiYWRtaW4iLCJleHAiOjE2NzkyOTk1NDMsImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.q_PXo6eyQpnsDYFlYep1oMUL22c_1Df3LbrsqJZqUC4'
    })
})

app.listen(8080, () => console.log('API is running on localhost:8080/login '))