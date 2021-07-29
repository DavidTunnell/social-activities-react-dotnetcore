import React from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { useState } from 'react';
import { useEffect } from 'react';
import { Header, List } from 'semantic-ui-react';

function App() {
//use state react hook - allows state to be stored inside component
const [activities, setActivities] = useState([]);
//use effects when component initalizes (load data from API)
useEffect(() => {
  axios.get("http://localhost:5000/api/activities").then(response => {
    console.log(response);
    setActivities(response.data);
  })
}, []);

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' /> 
        <List>          
          {activities.map((activity: any) => (
            //a key is always needed when looping HTML elements in react
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
