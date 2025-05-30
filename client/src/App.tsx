import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useState, useEffect } from "react"

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/activities')
      .then(response => setActivities(response.data));
    return () => {}
  }, [])

  return (
    <>
      <Typography variant="h4"> Welcome to the Reactivities application!</Typography>
      <List>
        {activities.map(activity => (
          <ListItem key={activity.id} style={{listStyleType: 'none'}}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default App
