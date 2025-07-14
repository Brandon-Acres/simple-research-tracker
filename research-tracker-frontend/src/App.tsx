import './App.css'
import ProjectList from './components/ProjectList'
import AddProjectForm from './components/AddProjectForm'

function App() {

  return (
    <>
      <div className='App'>
        <h1>Research Project Tracker</h1>
        <AddProjectForm />
        <ProjectList />
      </div>
    </>
  )
}

export default App
