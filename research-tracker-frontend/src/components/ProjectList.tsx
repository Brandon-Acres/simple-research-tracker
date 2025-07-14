import React, { useEffect, useState } from 'react';
import type { ResearchProject } from '../types/Project';
import axios from 'axios';

const ProjectList: React.FC = () => {
    const [projects, setProjects] = useState<ResearchProject[]>([]);
    const [loading, setLoading] = useState(true);

    const endpoint = 'http://localhost:5119/projects';

    useEffect(() => {
        axios.get(endpoint)
        .then(response => {
            setProjects(response.data);
            setLoading(false);
            console.log('successfully retrieved projects');
        })
        .catch(error => {
            console.error('Error fetching projects:', error);
            setLoading(false);
        });
    }, []);

    if (loading) return <p>Loading...</p>;

    return (
        <div>
            <h2>Research Projects</h2>
            <ul>
                {projects.map(project => (
                    <li key={project.id}>
                        <strong>{project.title}</strong> — PI: {project.principalInvestigator} — Status: {project.status} 
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ProjectList;