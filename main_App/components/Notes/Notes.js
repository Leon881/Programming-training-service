import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import './style.css';
import Loader from "../../containers/Loader";
import Status from '../../constants/Status';

export default function Notes ({notesList}){
    if (notesList.status === Status.loading) return <Loader fontColor='#fff'/>
    const notesForm=[];
    for (let note of notesList.notes){
        notesForm.push( <div key={note.id} className='note-form'><div className='note-title'>{note.title}</div>
        <div className='note-text'>{note.text}</div></div>)
    }
    return (
        <div className='notes-field'>
       {notesForm}
        </div>

    )
}

Notes.propTypes={
    notesList: PropTypes.object.isRequired
};