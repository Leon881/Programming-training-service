import React from 'react';
import PropTypes from 'prop-types';
import './style.css';
import Page from '../../constants/Page';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'

export default function NavigationMenu ({onNavigate}){
    return (
       <div className='menu-container' onClick= {(event)=>onNavigate(event.target.id)} >
          <Link className='text-link' to ='/articles'>
           <div id={Page.articles} className='block-menu' >
               <span className='menu-text'>Статьи</span>
            </div>
           </Link>
           <Link className='text-link' to ='/notes'>
            <div id={Page.notes} className='block-menu'>
              <span className='menu-text'>Заметки</span>
            </div>
           </Link>
           <Link className='text-link' to ='/study/sharp'>
            <div id={Page.studySharp} className='block-menu'>
              <span className='menu-text'>Обучение C#</span>
            </div>
           </Link>
           <Link className='text-link' to ='/tests'>
            <div id={Page.tests} className='block-menu'>
              <span className='menu-text'>Тесты</span>
            </div>
           </Link>
           <Link className='text-link' to ='/flashcards'>
            <div id={Page.flashCards} className='block-menu'>
              <span className='menu-text'>Флешкарты</span>
            </div>
           </Link>
       </div>
    )
}

NavigationMenu.propTypes={
    onNavigate: PropTypes.func.isRequired,
};