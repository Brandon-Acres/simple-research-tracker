import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ProjectList from './components/ProjectList'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div className='App'>
        <h1>Research Project Tracker</h1>
        <ProjectList />
      </div>
    </>
  )
}

export default App
