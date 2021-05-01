import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link, useRouteMatch} from 'react-router-dom'
import Status from '../../constants/Status';
import Page from "../../constants/Page";
import Loader from "../../containers/Loader"
import './style.css';

export default function Articles ({articlesList, onNavigateToPage, setLearningText, requestLearningText}) {
  if (articlesList.status === Status.loading) return <Loader fontColor='#fff'/>
  const openArticle = async (event)=>{
    await requestLearningText();
   // const text =await (await fetch(`/api/articles/${event.target.id}`)).text();
    const text='dsfd';
    await setLearningText(text);
  };
  const articlesForm=[];
  for (let el of articlesList.articles){
    articlesForm.push( <Link className='article-ref'  key={el.id} to={`${Page.articles.route}/${el.id}`} ><article onClick={openArticle}  className='article-item'> 
    <div className='image'  id={el.id} style={{'backgroundImage':`url(${el.image})`}}></div>
    <div id={el.id} className='article-data'>
      <div className='title' id={el.id}>{el.title}</div>
      <div id={el.id} className className='description'>{el.description}</div>
       <div id={el.id} className='info'>{el.date} / {el.author}</div>
       </div></article></Link>)

  }
    return (
    <div className='articles-menu'>
      <div className='articles-menu-list' onClick={(event) => onNavigateToPage('Статья № '+ event.target.id)}>
        {articlesForm}
      </div>
   </div>
      
    )
}

Articles.propTypes = {
  articlesList: PropTypes.object.isRequired,
  onNavigateToPage: PropTypes.func.isRequired,
  requestLearningText: PropTypes.func.isRequired,
  setLearningText: PropTypes.func.isRequired,
}
