import React, { useState, useRef, useEffect } from "react";
import ReactDOM from "react-dom";
import PropTypes from "prop-types";
import { createStore, applyMiddleware } from "redux";
import { rootReducer } from "../reducers";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import logger from "redux-logger";
import { Provider } from "react-redux";
import Page from "../constants/Page";
import testArticle from "../forTests/testArticle"
import NavigationMenu from "../containers/NavigationMenu";
import Articles from "../containers/Articles";
import ArticlePage from "../containers/ArticlePage";
import Notes from "../containers/Notes";
import TestArea from "../containers/TestArea";
import LanguageNavigation from "../containers/LanguageNavigation";
import TestsNavigation from "../containers/TestsNavigation";
import Learning from "../containers/Learning";
import FlashCardsDecks from "../containers/FlashCardsDecks";
import NotFound from "../containers/NotFound";
import "./style.css";
import { navigateToPage, setArticles, requestArticles, setLearningTextDefault, requestNotes, setNotes,
   setUserInformation } from "../actionCreators/index";

const store = createStore(rootReducer, applyMiddleware(logger));

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state={auth:false};
  }

  async componentDidMount() {
  this.authorization=await (await fetch('/account/checkout')).json();
  //this.authorization={userName:'Ivan'};
  this.setState({auth: this.authorization.isAuthenticated})
  await store.dispatch(setUserInformation(this.authorization));
  }
  render() {
    return (
      <Provider store={store}>
        <div className="page">
          <header id="header" className="header">
            <Link className='title-ref' to ='/'><div onClick= {()=>{store.dispatch(navigateToPage(Page.mainMenu.text)); store.dispatch(setLearningTextDefault()); }}
             className="header__logo">Programming-training service</div></Link>
            <div className="profile flex-block">
              {this.state.auth || <div className="link auth">
                  <a href="/account/login">Вход</a>
              </div>}
              {this.state.auth || <div className="link regist">
                 <a href="/account/register">Регистрация</a>
             </div>}
             {this.state.auth && <span>{this.authorization.userName}</span>}
             {this.state.auth && <div className="link logout">
                     <a href="/account/logout">Выход</a> </div>}
             </div>
          </header>
          <main className="content">
            <Switch>
              <Route exact path={Page.mainMenu.route} component={NavigationMenuPage} />
              <Route exact path={Page.articles.route} component={ArticlesPage} />
              <Route  path={`${Page.articles.route}/:id`} component={LearningArticlePage } />
              <Route exact path={Page.testsJS.route} component={TestsNavigationPage}/>
              <Route exact path={Page.testsSharp.route} component={TestsNavigationPage}/>
              <Route exact path={Page.testsSQL.route} component={TestsNavigationPage}/>
              <Route  path={ `${Page.testsJS.route}/:id`} component={TestPage}/>
              <Route  path={ `${Page.testsSharp.route}/:id`} component={TestPage}/>
              <Route  path={ `${Page.testsSQL.route}/:id`} component={TestPage}/>
              <Route exact path={Page.flashCards.route} component={FlashCardsPage} />
              <Route exact path={Page.notes.route} component={NotesPage} />
              <Route exact path={Page.testsMenu.route} component={LanguageNavigationPage} />
              <Route exact path={Page.learningMenu.route} component={LanguageNavigationPage} />
              <Route exact path={Page.learningSharp.route} component={LearningPage} />
              <Route exact path={Page.learningJS.route} component={LearningPage} />
              <Route exact path={Page.learningSQL.route} component={LearningPage} />
              <Route component={NotFoundPage} />
            </Switch>
          </main>
          <footer id="footer" className="footer">
            <div className="copyright-info">
                <a href="#header" className="copyright-info__logo"> 
                  <img src="src/img/vamLogo.jpg" alt="CompanyLogo" />
                </a>
            </div>
          </footer>
        </div>
      </Provider>
    );
  }
}

App.propTypes = {};

class NavigationMenuPage extends React.Component {
  render() {
    return (
        <NavigationMenu />
    );
  }
}

class ArticlesPage extends React.Component {
  async componentDidMount() {
     store.dispatch(requestArticles());
     //this.articles=await (await fetch('/api/articles')).json();
     //store.dispatch(setArticles(this.articles));
     store.dispatch(setArticles(testArticle));
  }
  render() {
    return (
        <Articles />
    );
  }
}

class LearningArticlePage extends React.Component {
  render() {
    return (
        <ArticlePage />
    );
  }
}

class FlashCardsPage extends React.Component {
  render() {
    return (
        <FlashCardsDecks />
    );
  }
}

class NotesPage extends React.Component {
  async componentDidMount() {
    const notes=[{id:1, title:'Заметка 1', text:'Текст 1'},{id:2, title:'Заметка 2', text:'Текст 2'},
    {id:3, title:'Заметка 3', text:'Текст 3'}, {id:4, title:'Заметка 4', text:'Текст 4'}];
    store.dispatch(requestNotes());
     //this.notes=await (await fetch('/api/notes')).json();
     //store.dispatch(setArticles(this.notes));
     store.dispatch(setNotes(notes));
  }
  render() {
    return (
        <Notes />
    );
  }
}

class LanguageNavigationPage extends React.Component {
  render() {
    return (
        <LanguageNavigation />
    );
  }
}

class TestsNavigationPage extends React.Component {
  render() {
    return (
        <TestsNavigation />
    );
  }
}

class TestPage extends React.Component {
  render() {
    return (
        <TestArea />
    );
  }
}

class LearningPage extends React.Component {
  render() {
    return (
        <Learning/>
    );
  }
}


class NotFoundPage extends React.Component {
  render() {
    return (
      <NotFound />
    );
  }
}

ReactDOM.render(
  <Router>
    <App />
  </Router>,
  document.getElementById("app")
);
