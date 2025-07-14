// Allow users to submit new research projects to backend via POST request

import React, { useState } from 'react';
import axios from 'axios';
import type { ResearchProject } from '../types/Project';

const AddProjectForm: React.FC = () => {
    const [title, setTitle] = useState('');
    const [principalInvestigator, setPI] = useState('');
    const [status, setStatus] = useState('');

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const newProject: Omit<ResearchProject, 'id'> = {
            title,
            principalInvestigator,
            status,
        };

        try {
            await axios.post('http://localhost:5119/projects', newProject);
            alert('Project added!');
            // clear form:
            setTitle('');
            setPI('');
            setStatus('');
        } catch (err) {
            console.error('Failed to add project', err);
            alert('Error adding project.');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h3>Add New Research Project</h3>
            <input 
                type="text"
                placeholder="Title"
                value={title}
                onChange={e => setTitle(e.target.value)}
                required
            />
            <input 
                type="text"
                placeholder="Principal Investigator"
                value={principalInvestigator}
                onChange={e => setPI(e.target.value)}
                required
            />
            <input
                type="text"
                placeholder="Status"
                value={status}
                onChange={e => setStatus(e.target.value)}
                required
            />
            <button type="submit">Add Project</button>
        </form>
    );
};

export default AddProjectForm;
