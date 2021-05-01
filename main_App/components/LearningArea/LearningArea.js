import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom';
import Page from "../../constants/Page";
import Status from '../../constants/Status';
import Loader from "../../containers/Loader"
import './style.css';

export default function LearningArea ({learningArea, pageIndication}){
    const submit = async (event)=>{
        event.preventDefault();
        console.log(document.getElementById('note-title').value);
        console.log(document.getElementById('note-text').value);
        /*
        await fetch(src, {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              //
            })
        });
        */
        document.location.href='#close';
        document.getElementById('note-title').value='';
        document.getElementById('note-text').value='';

    };
    return (
        <div className='learning-content'>
        <div className='learning-text' style={pageIndication ?{'maxWidth':'85%'}:{'maxWidth':'65%'}} >    <a title='Добавить заметку' href='#modal' className='button-note'></a> 
        {learningArea.status===Status.loading ? <Loader fontColor='black'/>:
         <div className='text' dangerouslySetInnerHTML={{__html:learningArea.text}} ></div>}</div> 
         <div id='modal' className='modal'>
             <div className='modal-wrapper'>
                <div className='modal-inner'>
                <div className='note-header'>Создание новой заметки</div>
                    <form className='modal-content' onSubmit={submit}>
                        <a title='Закрыть' href='#close' className='close-note'>X</a>
                        <input id='note-title' maxLength='40' required className='note-title' placeholder='Введите название заметки'></input>
                        <textarea id='note-text' maxLength='500' required className='note-text' placeholder='Введите текст заметки'></textarea>
                        <input value='Сохранить заметку' type='submit' className='save-note'></input>
                    </form>
                </div>
             </div>
         </div>
      </div>
    )
}

LearningArea.propTypes={
    learningArea: PropTypes.object.isRequired,
    pageIndication: PropTypes.bool.isRequired
};