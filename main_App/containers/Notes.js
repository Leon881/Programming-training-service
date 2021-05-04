import React from 'react';
import { connect } from 'react-redux';
import Notes from '../components/Notes/Notes';


export default connect(
    (state,props) => ({
        notesList: state.notesList
    }),
    (dispatch,props) =>({

    })
)(Notes)