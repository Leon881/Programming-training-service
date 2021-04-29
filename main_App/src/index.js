import React, {useState, useRef, useEffect} from "react";
import ReactDOM from "react-dom";
import PropTypes from 'prop-types';
import {createStore, applyMiddleware} from 'redux';
import {rootReducer} from '../reducers';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import logger from 'redux-logger';
import {Provider} from 'react-redux';
import NavigationMenu from '../containers/NavigationMenu'
import Articles from '../containers/Articles';
import ArticlesList from '../containers/ArticlesList';
import Notes from '../containers/Notes';
import Tests from '../containers/Tests';
import StudySharp from '../containers/StudySharp';
import FlashCardsDecks from '../containers/FlashCardsDecks';
import './style.css'
import {setArticlesList, setInformation} from '../actionCreators/index'
import { SET_ARTICLES_LIST } from "../actionTypes";

const store = createStore(rootReducer, applyMiddleware(logger));

class App extends React.Component {

    constructor(props){
        super(props);
    }

    async componentDidMount() {
       debugger;
       this.text = await (await fetch('api/lessons/1')).text();
       this.articlesList = await (await fetch('api/lessons')).json();
       debugger;
       store.dispatch(setInformation(this.text));
       store.dispatch(setArticlesList(this.articlesList));
    }
    render(){
        return (
           <Provider store={store}>
        <div className='wrapper'> 
          <header id='header'>
            <div className="product-logo flex-block">
                <span className="product-logo-text">
                  Programming-training service
               </span>
           </div>
          </header>
                <main className='content'> 
                <Switch>
                  <Route exact path='/' component={NavigationMenuPage} />
                  <Route exact path='/articles' component={ArticlesListPage} />
                  <Route exact path='/article' component={ArticlesPage} />
                  <Route exact path='/flashcards' component={FlashCardsPage} />
                  <Route exact path='/notes' component={NotesPage} />
                  <Route exact path='/tests' component={TestsPage} />
                  <Route exact path='/study/sharp' component={StudySharpPage} />
                  <Route component={NotFound} />
                </Switch>
                 </main>
               <footer id="footer">
                    <div className="flex-block copiryght-info">
                        <p className='copiryght-info-text'>Powered By</p>
                    </div>
                </footer>
            </div>
            </Provider>
        )
    }
}

App.propTypes = {};



class NavigationMenuPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
           <NavigationMenu/>
            </Provider>
        )
    }
}
class ArticlesListPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
            <ArticlesList/>
            </Provider>
        )
    }
}

class ArticlesPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
           <Articles/>
            </Provider>
        )
    }
}

class FlashCardsPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
           <FlashCardsDecks/>
            </Provider>
        )
    }
}

class NotesPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
           <Notes/>
            </Provider>
        )
    }
}

class TestsPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
           <Tests/>
            </Provider>
        )
    }
}
class StudySharpPage extends React.Component {
    render(){
        return (
           <Provider store={store}>
           <StudySharp/>
            </Provider>
        )
    }
}

class NotFound extends React.Component{
    render(){
        return <h2><Link to ='/'>Ресурс не найден</Link></h2>;
    }
}

ReactDOM.render(<Router>
  <App/>
</Router>, document.getElementById("app"));